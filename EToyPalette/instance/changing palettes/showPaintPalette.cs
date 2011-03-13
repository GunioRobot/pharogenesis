showPaintPalette

	paintPalette ifNil: [paintPalette _ PaintBoxMorph new].
	currentPalette == paintPalette ifTrue: [^ self].
	self highlightPaletteName: self labelForPaintPalette.
	self showPalette: paintPalette.
	self world displayWorld.
	self world stopRunningAll.
	self primaryHand makeNewDrawing.
	owner addMorphFront: paintPalette.	"Force in front of drawing, so colorPicker will show"