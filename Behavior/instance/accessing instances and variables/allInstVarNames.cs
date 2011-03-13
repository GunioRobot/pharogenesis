allInstVarNames
	"Answer an Array of the names of the receiver's instance variables. The 
	Array ordering is the order in which the variables are stored and 
	accessed by the interpreter."

	| vars |
	superclass == nil
		ifTrue: [vars _ self instVarNames copy]	"Guarantee a copy is answered."
		ifFalse: [vars _ superclass allInstVarNames , self instVarNames].
	^vars