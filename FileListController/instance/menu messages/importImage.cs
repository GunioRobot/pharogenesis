importImage
	"Import the selected image file, storing the resulting Form or ColorForm in the global GIFImports dictionary at a key derived from the filename."

	model isLocked ifTrue: [^ view flash].
	self controlTerminate.
	model importImage.
	self controlInitialize.
