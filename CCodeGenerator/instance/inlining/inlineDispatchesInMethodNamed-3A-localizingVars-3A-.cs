inlineDispatchesInMethodNamed: selector localizingVars: varsList
	"Inline dispatches (case statements) in the method with the given name."

	| m varString |
	m _ self methodNamed: selector.
	m = nil ifFalse: [
		m inlineCaseStatementBranchesIn: self localizingVars: varsList.
		m parseTree nodesDo: [ :n |
			n isCaseStmt ifTrue: [
				n customizeShortCasesForDispatchVar: 'currentBytecode' in: self method: m.
			].
		].
	].
	variables _ variables asOrderedCollection.
	varsList do: [ :v |
		varString _ v asString.
		variables remove: varString ifAbsent: [].
		(variableDeclarations includesKey: varString) ifTrue: [
			m declarations at: v asString put: (variableDeclarations at: varString).
			variableDeclarations removeKey: varString.
		].
	].
