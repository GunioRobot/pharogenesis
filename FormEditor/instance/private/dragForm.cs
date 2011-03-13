dragForm

	tool = #block
		ifTrue:
			[Cursor origin show.
			[sensor anyButtonPressed
				or: [sensor keyboardPressed
				or: [self viewHasCursor not]]]
				whileFalse: [].
			^self cursorPoint]
		ifFalse:
			[^self trackFormUntil:
				[sensor anyButtonPressed
					or: [sensor keyboardPressed
					or: [self viewHasCursor not]]]]