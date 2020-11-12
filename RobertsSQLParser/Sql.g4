/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2014 by Bart Kiers
 * Copyright (c) 2020 by rmacfadyen
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * Converted from SQLite to Microsoft SQL Server. Based on 
 * https://github.com/bkiers/sqlite-parser
 */


grammar Sql;


 root
 : ( expr | error ) EOF
 ;

error
 : UNEXPECTED_CHAR 
 ;


select_stmt
 : 
   select_or_values ( compound_operator select_or_values )*
   ( K_ORDER K_BY ordering_term ( ',' ordering_term )* )?
 ;

select_or_values
 : K_SELECT ( K_DISTINCT | K_ALL | K_TOP NUMERIC_LITERAL )? result_column ( ',' result_column )*
   ( K_FROM ( table_or_subquery ( ',' table_or_subquery )* | join_clause ) )?
   ( where_clause )?
   ( K_GROUP K_BY expr ( ',' expr )* ( K_HAVING expr )? )?
 ;

 where_clause
 : K_WHERE expr
 ;

type_name
 : name ( '(' signed_number (any_name)? ')'
         | '(' signed_number (any_name)? ',' signed_number (any_name)? ')' )?
 ;

/*
    SQL understands the following binary operators

    *    /    %
    +    -
    <<   >>   &    |
    <    <=   >    >=
    =    ==   !=   <>   IS   IS NOT   IN   LIKE 
    AND
    OR
*/
expr
 : literal_value
 | variableName
 | qualified_column_name
 | unary_operator expr
 | expr ( '*' | '/' | '%' ) expr
 | expr ( '+' | '-' ) expr
 | expr ( '<<' | '>>' | '&' | '|' ) expr
 | expr ( '<' | '<=' | '>' | '>=' ) expr
 | expr ( '=' | '==' | '!=' | '<>' | K_IS | K_IS K_NOT | K_IN | K_LIKE ) expr
 | expr K_AND expr
 | expr K_OR expr
 | functionCall
 | '(' expr ')'
 | K_CAST '(' expr K_AS type_name ')'
 | expr K_COLLATE collation_name
 | expr K_NOT? ( K_LIKE ) expr ( K_ESCAPE expr )?
 | expr K_IS K_NULL
 | expr K_IS K_NOT K_NULL
 | expr K_NOT? K_BETWEEN expr K_AND expr
 | expr K_NOT? K_IN ( '(' ( select_stmt
                          | expr ( ',' expr )*
                          ) 
                      ')'
                    )
 | ( ( K_NOT )? K_EXISTS )? '(' select_stmt ')'
 | K_CASE expr? ( K_WHEN expr K_THEN expr )+ ( K_ELSE expr )? K_END
 ;



 /* need special handling of left() and right() because those keywords also match joins */
 functionCall
 : ( schema_name '.' )? function_name '(' ( (K_DISTINCT | K_ALL)? expr ( ',' expr )* | '*' )? ')' 
 | K_LEFT '(' expr? (',' expr)* ')'
 | K_RIGHT '(' expr? (',' expr)* ')'
 ;

 variableName
 : VARIABLE
 ;


qualified_column_name
: ( ( ( database_name? '.')? schema_name? '.' )? table_name '.' )? column_name
;


ordering_term
 : expr ( K_COLLATE collation_name )? ( K_ASC | K_DESC )?
 ;



result_column
 : '*'
 | table_name '.' '*'
 | expr ( K_AS? column_alias )?
 ;

table_or_subquery
 : ( schema_name '.' )? table_name ( K_AS? table_alias )?
 | '(' ( table_or_subquery ( ',' table_or_subquery )*
       | join_clause )
   ')' ( K_AS? table_alias )?
 | '(' select_stmt ')' ( K_AS? table_alias )?
 ;

join_clause
 : table_or_subquery ( join_operator table_or_subquery join_constraint )*
 ;

join_operator
 : ','
 | (( K_LEFT K_OUTER? | K_RIGHT K_OUTER? | K_FULL K_OUTER? | K_CROSS)? K_JOIN )
 ;

join_constraint
 : ( K_ON expr )?
 ;



compound_operator
 : K_UNION
 | K_UNION K_ALL
 | K_INTERSECT
 | K_EXCEPT
 ;


signed_number
 : ( ( '+' | '-' )? NUMERIC_LITERAL | '*' )
 ;

literal_value
 : NUMERIC_LITERAL
 | STRING_LITERAL
 | UNICODE_LITERAL
 | BLOB_LITERAL
 | K_NULL
 ;

unary_operator
 : '-'
 | '+'
 | '~'
 | K_NOT
 ;



column_alias
 : IDENTIFIER
 | STRING_LITERAL
 ;

keyword
 : K_ALL
 | K_AND
 | K_AS
 | K_ASC
 | K_BETWEEN
 | K_BY
 | K_CASE
 | K_CAST
 | K_COLLATE
 | K_COLUMN
 | K_CROSS
 | K_DESC
 | K_DISTINCT
 | K_ELSE
 | K_END
 | K_ESCAPE
 | K_EXCEPT
 | K_EXISTS
 | K_FROM
 | K_FULL
 | K_GROUP
 | K_HAVING
 | K_IN
 | K_INNER
 | K_INTERSECT
 | K_IS
 | K_JOIN
 | K_LEFT
 | K_LIKE
 | K_NATURAL
 | K_NOT
 | K_NULL
 | K_ON
 | K_OR
 | K_ORDER
 | K_OUTER
 | K_RIGHT
 | K_SELECT
 | K_TOP
 | K_THEN
 | K_UNION
 | K_UNIQUE
 | K_WHEN
 | K_WHERE
 ;

// TODO check all names below

name
 : any_name
 ;

function_name
 : IDENTIFIER
 | IDENTIFIER '.' IDENTIFIER
 ;


database_name
 : any_name
 ;

schema_name 
 : any_name
 ;

table_name 
 : any_name
 ;

column_name 
 : any_name
 ;

collation_name 
 : any_name
 ;

table_alias 
 : any_name
 ;

any_name
 : IDENTIFIER 
 | keyword
 | STRING_LITERAL
 | '(' any_name ')'
 ;

SCOL : ';';
DOT : '.';
OPEN_PAR : '(';
CLOSE_PAR : ')';
COMMA : ',';
ASSIGN : '=';
STAR : '*';
PLUS : '+';
MINUS : '-';
TILDE : '~';
PIPE2 : '||';
DIV : '/';
MOD : '%';
LT2 : '<<';
GT2 : '>>';
AMP : '&';
PIPE : '|';
LT : '<';
LT_EQ : '<=';
GT : '>';
GT_EQ : '>=';
EQ : '==';
NOT_EQ1 : '!=';
NOT_EQ2 : '<>';

//
// SQL keywords (used above)
//  - Done this way because ANTLR isn't fond of case insensitive grammars
//
K_ALL : A L L;
K_AND : A N D;
K_AS : A S;
K_ASC : A S C;
K_BETWEEN : B E T W E E N;
K_BY : B Y;
K_CASE : C A S E;
K_CAST : C A S T;
K_COLLATE : C O L L A T E;
K_COLUMN : C O L U M N;
K_CROSS : C R O S S;
K_DESC : D E S C;
K_DISTINCT : D I S T I N C T;
K_ELSE : E L S E;
K_END : E N D;
K_ESCAPE : E S C A P E;
K_EXCEPT : E X C E P T;
K_EXISTS : E X I S T S;
K_FROM : F R O M;
K_FULL : F U L L;
K_GROUP : G R O U P;
K_HAVING : H A V I N G;
K_IN : I N;
K_INNER : I N N E R;
K_INTERSECT : I N T E R S E C T;
K_IS : I S;
K_JOIN : J O I N;
K_LEFT : L E F T;
K_LIKE : L I K E;
K_NATURAL : N A T U R A L;
K_NOT : N O T;
K_NULL : N U L L;
K_ON : O N;
K_OR : O R;
K_ORDER : O R D E R;
K_OUTER : O U T E R;
K_RIGHT : R I G H T;
K_SELECT : S E L E C T;
K_THEN : T H E N;
K_TOP : T O P;
K_UNION : U N I O N;
K_UNIQUE : U N I Q U E;
K_WHEN : W H E N;
K_WHERE : W H E R E;

IDENTIFIER
 : '[' ~']'* ']'
 | [a-zA-Z_] [a-zA-Z_0-9]* // TODO check: needs more chars in set
 ;

NUMERIC_LITERAL
 : DIGIT+ ( '.' DIGIT* )? ( E [-+]? DIGIT+ )?
 | '.' DIGIT+ ( E [-+]? DIGIT+ )?
 ;

VARIABLE
 : [@] IDENTIFIER
 ;

STRING_LITERAL
 : '\'' ( ~'\'' | '\'\'' )* '\''
 ;

UNICODE_LITERAL
 : N STRING_LITERAL
 ;

BLOB_LITERAL
 : X STRING_LITERAL
 ;

SINGLE_LINE_COMMENT
 : '--' ~[\r\n]* -> channel(HIDDEN)
 ;

SPACES
 : [ \u000B\t\r\n] -> channel(HIDDEN)
 ;

UNEXPECTED_CHAR
 : . 
 ;

fragment DIGIT : [0-9];

fragment A : [aA];
fragment B : [bB];
fragment C : [cC];
fragment D : [dD];
fragment E : [eE];
fragment F : [fF];
fragment G : [gG];
fragment H : [hH];
fragment I : [iI];
fragment J : [jJ];
fragment K : [kK];
fragment L : [lL];
fragment M : [mM];
fragment N : [nN];
fragment O : [oO];
fragment P : [pP];
fragment Q : [qQ];
fragment R : [rR];
fragment S : [sS];
fragment T : [tT];
fragment U : [uU];
fragment V : [vV];
fragment W : [wW];
fragment X : [xX];
fragment Y : [yY];
fragment Z : [zZ];



