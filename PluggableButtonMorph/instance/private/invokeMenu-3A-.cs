invokeMenu: evt
	"Invoke my menu in response to the given event."

	| menu |
	menu _ self getMenu: evt.
	menu ifNotNil: [
		menu popUpAt: evt cursorPoint event: evt].
