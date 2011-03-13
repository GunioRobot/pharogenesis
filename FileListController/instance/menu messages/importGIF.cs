importGIF
	"Import the selected file as a GIF file, putting it into the global GIFImports dictionary at a key that is a function of the filename.  7/18/96 sw"

	model isLocked ifTrue: [^ view flash].

	self controlTerminate.
	model importGIF.
	self controlInitialize