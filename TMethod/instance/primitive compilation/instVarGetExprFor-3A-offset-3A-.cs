instVarGetExprFor: varName offset: instIndex
	"Return the parse tree for an expression that fetches and converts the value of the instance variable at the given offset."

	| exprList decl stmtList |
	exprList _ OrderedCollection new.
	(declarations includesKey: varName) ifTrue: [
		decl _ declarations at: varName.
		(decl includes: $*) ifTrue: [  "array"
			exprList add:
				(varName, ' _ ', self vmNameString, ' fetchArray: ', instIndex printString, ' ofObject: rcvr').
			exprList add: (varName, ' _ ', varName, ' - 1').
		] ifFalse: [  "must be a double"
			((decl findString: 'double' startingAt: 1) = 0)
				ifTrue: [ self error: 'unsupported type declaration in a primitive method' ].
			exprList add:
				(varName, ' _ ', self vmNameString, ' fetchFloat: ', instIndex printString, ' ofObject: rcvr').
		].
	] ifFalse: [  "undeclared variables are taken to be integer"
		exprList add:
			(varName, ' _ ', self vmNameString, ' fetchInteger: ', instIndex printString, ' ofObject: rcvr').
	].
	stmtList _ OrderedCollection new.
	exprList do: [:e | stmtList addAll: (self statementsFor: e varName: varName)].
	^ stmtList
