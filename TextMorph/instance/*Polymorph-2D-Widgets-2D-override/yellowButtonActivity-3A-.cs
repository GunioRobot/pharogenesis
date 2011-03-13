yellowButtonActivity: shiftKeyState 
	"Invoke the text-editing menu.
	Check if required first!"
	
	| menu |
	self wantsYellowButtonMenu
		ifFalse: [^self].
	(menu := self getMenu: shiftKeyState)
		ifNotNil: [""
			menu setInvokingView: self editor.
			menu invokeModal. self changed]