setExpression: aNode selectors: selectorList arguments: anArray
	"Initialize the node from the given set of selectors."
	"Note: Each case is a statement list with containing one statement, a send to self of a selector from the given selector list. Having statement list nodes makes inlining easier later."

	| selfNode stmt lastSel firstInRun sel |
	expression _ aNode.
	selfNode _ TVariableNode new setName: 'self'.
	firsts _ OrderedCollection new: 400.
	lasts _ OrderedCollection new: 400.
	cases _ OrderedCollection new: 400.
	lastSel _ selectorList first.
	firstInRun _ 0.
	1 to: selectorList size do: [ :i |
		sel _ selectorList at: i.
		sel ~= lastSel ifTrue: [
			firsts add: firstInRun.
			lasts add: i - 2.
			stmt _ TSendNode new setSelector: lastSel receiver: selfNode arguments: anArray.
			cases add: (TStmtListNode new setArguments: #() statements: (Array with: stmt)).
			lastSel _ sel.
			firstInRun _ i - 1.
		].
	].
	firsts add: firstInRun.
	lasts add: selectorList size - 1.
	stmt _ TSendNode new setSelector: lastSel receiver: selfNode arguments: anArray.
	cases add: (TStmtListNode new setArguments: #() statements: (Array with: stmt)).