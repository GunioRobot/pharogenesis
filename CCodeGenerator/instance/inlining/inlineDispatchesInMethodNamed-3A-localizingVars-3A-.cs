inlineDispatchesInMethodNamed: selector localizingVars: varsList
	"Inline dispatches (case statements) in the method with the given name."

	| m |
	m _ self methodNamed: selector.
	m = nil ifFalse: [
		m inlineCaseStatementBranchesIn: self localizingVars: varsList.
		m parseTree nodesDo: [ :n |
			n isCaseStmt ifTrue: [
				n customizeShortCasesForDispatchVar: #currentBytecode.
			].
		].
	].
	variables _ variables asOrderedCollection.
	varsList do: [ :v |
		variables remove: v asString ifAbsent: [].
		(variableDeclarations includesKey: v asString) ifTrue: [
			m declarations at: v asString put: (variableDeclarations at: v asString).
			variableDeclarations removeKey: v asString.
		].
	].
