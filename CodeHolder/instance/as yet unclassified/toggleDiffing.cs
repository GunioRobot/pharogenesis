toggleDiffing
	| showing |
	showing _ self showDiffs.
	self toggleDiff.
	showing = self showDiffs ifTrue: ["cancelled out" ^ self].

	self inform: (showDiffs
		ifTrue:
			['Okay, diffs will be shown']
		ifFalse:
			['Okay, diffs will no longer be shown'])
