extractScreenRegion: poly andPutSketchInHand: hand
	"The user has specified a polygonal area of the Display.
	Now capture the pixels from that region, and put in the hand as a Sketch."
	| screenForm outline topLeft innerForm exterior |
	outline _ poly shadowForm.
	topLeft _ outline offset.
	exterior _ (outline offset: 0@0) anyShapeFill reverse.
	screenForm _ Form fromDisplay: (topLeft extent: outline extent).
	screenForm eraseShape: exterior.
	innerForm _ screenForm trimBordersOfColor: Color transparent.
	innerForm isAllWhite ifFalse:
		[hand attachMorph: (self drawingClass withForm: innerForm)]