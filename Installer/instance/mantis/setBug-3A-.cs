setBug: stringOrNumber
 
  | str |
 
 stringOrNumber isInteger ifTrue: [ bug := stringOrNumber. desc := ''. ^self ].
 
 bug := stringOrNumber asInteger.
 str := str printString. 
 desc := stringOrNumber copyFrom: (str size + 1) to: (stringOrNumber size) 