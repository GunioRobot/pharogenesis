valueAtCursor

	submorphs isEmpty ifTrue: [^ 0].
	^ submorphs at: ((cursor truncated max: 1) min: submorphs size)
