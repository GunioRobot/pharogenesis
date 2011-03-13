setDate: aDate fromButton: aButton down: down

	dateButtonPressed ifNotNil: [dateButtonPressed setSwitchState: false].
	down ifTrue: [self selectDate: aDate.
				dateButtonPressed _ aButton]
		ifFalse: [self selectDate: nil.
				dateButtonPressed _ nil].
	self currentItem: nil.
	aButton ifNotNil: [aButton owner owner highlightToday] "ugly hack to restore highlight for today"