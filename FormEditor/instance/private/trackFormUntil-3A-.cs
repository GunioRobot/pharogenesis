trackFormUntil: aBlock

	| previousPoint cursorPoint displayForm |
	previousPoint := self cursorPoint.
	displayForm := Form extent: form extent depth: form depth.
	displayForm copy: (0 @ 0 extent: form extent)
	               from: form
	               to: 0 @ 0
	               rule: Form over.
	Display depth > 1 ifTrue: [displayForm reverse]. 
	displayForm displayOn: Display at: previousPoint rule: Form reverse.
	[aBlock value] whileFalse:
		[cursorPoint := self cursorPoint.
		(FlashCursor or: [cursorPoint ~= previousPoint])
			ifTrue:
			[displayForm displayOn: Display at: previousPoint rule: Form reverse.
			displayForm displayOn: Display at: cursorPoint rule: Form reverse.
			previousPoint := cursorPoint]].
	displayForm displayOn: Display at: previousPoint rule: Form reverse.
	^previousPoint