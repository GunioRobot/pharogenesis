exampleDraw: subdivision points: ptList
	| canvas |
	Display fillWhite.
	canvas _ Display getCanvas.
	subdivision edgesDo:[:e|
		canvas line: e origin to: e destination width: 1 color: e classificationColor].
	ptList do:[:pt|
		canvas fillRectangle: (pt - 1 extent: 3@3) color: Color red.
	].
	Display restoreAfter:[].