setInstVarNames: instVarArray
	"Private - for class initialization only"
	| required |
	required _ self instSize.
	superclass notNil ifTrue:[required _ required - superclass instSize].
	instVarArray size = required
		ifFalse:[^self error: required printString, ' instvar names are required'].
	instVarArray isEmpty
		ifTrue:[instanceVariables _ nil]
		ifFalse:[instanceVariables _ instVarArray asArray].