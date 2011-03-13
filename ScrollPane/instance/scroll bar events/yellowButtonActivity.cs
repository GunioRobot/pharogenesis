yellowButtonActivity
	| menu event |
	(menu _ self getMenu: false) ifNotNil:
		[event _ self primaryHand lastEvent.
		menu setInvokingView: self.
		menu popUpAt: event cursorPoint event: event]