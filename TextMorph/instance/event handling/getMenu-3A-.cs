getMenu: shiftKeyState 
	^ shiftKeyState not
		ifTrue: [ParagraphEditor yellowButtonMenu]
		ifFalse: [ParagraphEditor shiftedYellowButtonMenu]