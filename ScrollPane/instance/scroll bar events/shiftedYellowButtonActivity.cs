shiftedYellowButtonActivity
	| menu event |
	(menu _ self getMenu: true) ifNotNil:
		[event _ self primaryHand lastEvent.
		menu setInvokingView: self.
		menu popUpAt: event cursorPoint event: event]