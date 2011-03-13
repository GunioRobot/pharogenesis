scrollBarMenuButtonPressed: event
	| menu |
	(menu _ self getMenu) ifNotNil:
		[menu popUpAt: event cursorPoint event: event]