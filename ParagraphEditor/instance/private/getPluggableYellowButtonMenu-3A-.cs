getPluggableYellowButtonMenu: shiftKeyState
	| customMenu |
	^(customMenu _ view getMenu: shiftKeyState) notNil
		ifTrue: [customMenu]
		ifFalse:
			[shiftKeyState
				ifTrue: [self class shiftedYellowButtonMenu]
				ifFalse: [self class yellowButtonMenu]]