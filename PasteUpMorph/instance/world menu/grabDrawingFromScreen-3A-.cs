grabDrawingFromScreen: evt
	"Allow the user to specify a rectangular area of the Display, capture the pixels from that area, and use them to create a new drawing morph. Attach the result to the hand."
	| m |
	m _ self drawingClass new form: Form fromUser.
	evt hand attachMorph: m.