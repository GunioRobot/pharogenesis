statementsListsForInlining
	"Answer a collection of statement list nodes that are candidates for inlining. Currently, we cannot inline into the argument blocks of and: and or: messages."

	| stmtLists |
	stmtLists _ OrderedCollection new: 10.
	parseTree nodesDo: [ :node | 
		node isStmtList ifTrue: [ stmtLists add: node ].
	].
	parseTree nodesDo: [ :node | 
		node isSend ifTrue: [
			((node selector = #and:) or: [node selector = #or:]) ifTrue: [
				"Note: the PP 2.3 compiler produces two arg nodes for these selectors"
				stmtLists remove: node args first ifAbsent: [].
				stmtLists remove: node args last ifAbsent: [].
			].
			((node selector = #ifTrue:) or: [node selector = #ifFalse:]) ifTrue: [
				stmtLists remove: node receiver ifAbsent: [].
			].
			((node selector = #ifTrue:ifFalse:) or: [node selector = #ifFalse:ifTrue:]) ifTrue: [
				stmtLists remove: node receiver ifAbsent: [].
			].
			((node selector = #whileFalse:) or: [node selector = #whileTrue:]) ifTrue: [
				stmtLists remove: node receiver ifAbsent: [].
			].
			(node selector = #to:do) ifTrue: [
				stmtLists remove: node receiver ifAbsent: [].
				stmtLists remove: node args first ifAbsent: [].
			].
			(node selector = #to:do) ifTrue: [
				stmtLists remove: node receiver ifAbsent: [].
				stmtLists remove: node args first ifAbsent: [].
				stmtLists remove: (node args at: 2) ifAbsent: [].
			].
		].
		node isCaseStmt ifTrue: [
			"don't inline cases"
			node cases do: [: case | stmtLists remove: case ifAbsent: [] ].
		].
	].
	^stmtLists