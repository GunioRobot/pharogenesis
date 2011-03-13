scrollBarMenuButtonPressed: event
	| menu |
	(menu _ self getMenu: event shiftPressed) ifNotNil:
		["Set up to use perform:orSendTo: for model/view dispatch"
		menu setInvokingView: self.
		menu popUpEvent: event in: self world]