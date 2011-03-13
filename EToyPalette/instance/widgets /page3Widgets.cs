page3Widgets
	| anEToyHolder |
	anEToyHolder _ self world standardHolder.
	^ #(PasteUpMorph JoystickMorph BookMorph) collect: 
		[:sym | (Smalltalk at: sym) authoringPrototypeIn: anEToyHolder]