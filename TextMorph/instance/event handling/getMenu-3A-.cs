getMenu: shiftKeyState 
	^ (shiftKeyState not
			or: [Preferences noviceMode])
		ifTrue: [ParagraphEditor yellowButtonMenu]
		ifFalse: [ParagraphEditor shiftedYellowButtonMenu]