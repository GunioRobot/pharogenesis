initializeWith: aForm

	super initialize.
	originalForm _ aForm.
	rotationCenter _ 7@5.		"relative to the top-left corner of the Form"
	rotationDegrees _ 0.0.		"clockwise angle of rotation"
	rotationStyle _ #normal.		"styles: #normal, #leftRight, #upDown, or #none"
	scalePoint _ 1.0@1.0.
	framesToDwell _ 1.
	rotatedForm _ originalForm.	"cached rotation of originalForm"
	offsetWhenRotated _ 0@0.	"offset for rotated form"
	self extent: originalForm extent.
