removeMethodsReferingToGlobals: varList except: methodName
	"Remove any methods (presumably inlined) that still contain references to the given obsolete global variables."

	| varListAsStrings removeIt mVars |
	varListAsStrings _ varList collect: [ :sym | sym asString ].
	methods keys copy do: [ :sel |
		removeIt _ false.
		mVars _ (self methodNamed: sel) freeVariableReferences asSet.
		varListAsStrings do: [ :v |
			(mVars includes: v) ifTrue: [ removeIt _ true ].
		].
		(removeIt and: [sel ~= methodName]) ifTrue: [
			methods removeKey: sel ifAbsent: [].
		].
	].