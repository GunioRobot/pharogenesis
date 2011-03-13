scrollBarMenuButtonPressed: event
	| menu |
	(menu _ self getMenu) ifNotNil:
		["Set up to use perform:orSendTo: for model/view dispatch"
		menu setInvokingView: self.
		menu popUpAt: event cursorPoint event: event]