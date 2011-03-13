initialize

	super initialize.
	originalForm _ (ScriptingSystem formAtKey: 'Painting') deepCopy.
	"(Form extent: 14@10 depth: 8) fillColor: Color gray."
	rotationCenter _ 7@5.		"relative to the top-left corner of the Form"
	rotationDegrees _ 0.0.		"clockwise angle of rotation"
	rotationStyle _ #normal.		"styles: #normal, #leftRight, #upDown, or #none"
	scalePoint _ 1.0@1.0.
	framesToDwell _ 1.
	rotatedForm _ originalForm.	"cached rotation of originalForm"
	offsetWhenRotated _ 0@0.	"offset for rotated form"
	self extent: originalForm extent.
