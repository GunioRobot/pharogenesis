setBoundsOfPaneMorphs
	| panelRect bookBorder bookExtent |
	panelRect _ self panelRect.
	book ifNotNil:
		[book bounds: ((panelRect origin + (bookBorder _ book borderWidth asPoint)) 
			extent: (bookExtent _ panelRect extent - (2 * bookBorder))).
		book resizePagesTo: (bookExtent - (7 @ 7))]