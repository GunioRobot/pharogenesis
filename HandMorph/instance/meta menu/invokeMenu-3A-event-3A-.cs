invokeMenu: aMenu event: evt
	"Invoke the given menu."

	aMenu popUpAt: evt cursorPoint event: evt.
