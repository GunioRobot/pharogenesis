yellowButtonActivity: shiftKeyState
	| menu |
	(menu _ self getMenu: shiftKeyState) ifNotNil:
		[menu setInvokingView: self.
		menu popUpEvent: self activeHand lastEvent]