yellowButtonActivity: shiftKeyState
	"Invoke the text-editing menu"

	| menu |
	(menu _ self getMenu: shiftKeyState) ifNotNil:
		[menu setInvokingView: self.
		menu invokeModal]