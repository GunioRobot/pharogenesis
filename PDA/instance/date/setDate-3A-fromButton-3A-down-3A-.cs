setDate: aDate fromButton: aButton down: down 
	dateButtonPressed ifNotNil: [dateButtonPressed setSwitchState: false].
	dateButtonPressed := down 
				ifTrue:  
					[self selectDate: aDate.
					aButton]
				ifFalse: 
					[self selectDate: nil.
					nil].
	self currentItem: nil.
	aButton ifNotNil: 
			[aButton owner owner highlightToday	"ugly hack to restore highlight for today"]