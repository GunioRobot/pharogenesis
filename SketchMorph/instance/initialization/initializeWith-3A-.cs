initializeWith: aForm

	super initialize.
	originalForm _ aForm.
	self rotationCenter: 0.5@0.5.		"relative to the top-left corner of the Form"
	rotationStyle _ #normal.		"styles: #normal, #leftRight, #upDown, or #none"
	scalePoint _ 1.0@1.0.
	framesToDwell _ 1.
	rotatedForm _ originalForm.	"cached rotation of originalForm"
	self extent: originalForm extent.
