shiftedYellowButtonMenu
	^ (model respondsTo: #shiftedYellowButtonMenu)
		ifTrue:
			[model shiftedYellowButtonMenu]
		ifFalse:
			[super shiftedYellowButtonMenu]