argConversionExprFor: varName stackIndex: stackIndex
	"Return the parse tree for an expression that fetches and converts the primitive argument at the given stack offset."

	| expr decl |
	expr _ '(self stackValue: ( ', stackIndex printString, '))'.
	(declarations includesKey: varName) ifTrue: [  "array"
		decl _ declarations at: varName.
		(decl includes: $*) ifTrue: [
			expr _ varName, ' _ self arrayValueOf: ', expr.
		] ifFalse: [  "must be a double"
			((decl findString: 'double' startingAt: 1) = 0)
				ifTrue: [ self error: 'unsupported type declaration in a primitive method' ].
			expr _ varName, ' _ self floatValueOf: ', expr.
		].
	] ifFalse: [  "undeclared variables are taken to be integer"
		expr _ varName, ' _ self checkedIntegerValueOf: ', expr.
	].
	^ self statementsFor: expr varName: varName
