argConversionExprFor: varName stackIndex: stackIndex
	"Return the parse tree for an expression that fetches and converts the primitive argument at the given stack offset."

	| exprList expr decl stmtList |
	exprList _ OrderedCollection new.
	expr _ '(self stackValue: ( ', stackIndex printString, '))'.
	(declarations includesKey: varName) ifTrue: [  "array"
		decl _ declarations at: varName.
		(decl includes: $*) ifTrue: [
			exprList add: (varName, ' _ self arrayValueOf: ', expr).
			exprList add: (varName, ' _ ', varName, ' - 1').
		] ifFalse: [  "must be a double"
			((decl findString: 'double' startingAt: 1) = 0)
				ifTrue: [ self error: 'unsupported type declaration in a primitive method' ].
			exprList add: (varName, ' _ self floatValueOf: ', expr).
		].
	] ifFalse: [  "undeclared variables are taken to be integer"
		exprList add: (varName, ' _ self checkedIntegerValueOf: ', expr).
	].
	stmtList _ OrderedCollection new.
	exprList do: [:e | stmtList addAll: (self statementsFor: e varName: varName)].
	^ stmtList
