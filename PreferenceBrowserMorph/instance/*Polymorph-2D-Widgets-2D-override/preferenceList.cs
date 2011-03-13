preferenceList
	"Changed to take mouseClickForKeyboardFocus preference into account."
	
	^preferenceList ifNil:
		[preferenceList := ScrollPane new
			color: Color white;
			borderStyle: (BorderStyle inset width: 1);
			vResizing: #spaceFill;
			hResizing: #spaceFill;
			cornerStyle: StandardWindow basicNew preferredCornerStyle.
		Preferences mouseClickForKeyboardFocus
			ifFalse: [preferenceList scroller
						on: #mouseEnter send: #value: 
						to: [:event | preferenceList scroller takeKeyboardFocus]].
		preferenceList scroller
			on: #keyStroke send: #keyPressed: to: self.
		preferenceList]