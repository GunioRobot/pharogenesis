makeNewDrawing
	"Make a new drawing in the standard playfield."

	| aPlayfield |
	(aPlayfield _ self world playfield) ifNil: [aPlayfield _ self world].
	self makeNewDrawingInBounds: aPlayfield paintingBounds pasteUpMorph: aPlayfield
