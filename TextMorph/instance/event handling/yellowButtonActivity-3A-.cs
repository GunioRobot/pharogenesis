yellowButtonActivity: shiftKeyState 
	"Invoke the text-editing menu"
	| menu |
	(menu := self getMenu: shiftKeyState)
		ifNotNil: [""
			menu setInvokingView: self editor.
			menu invokeModal. self changed]