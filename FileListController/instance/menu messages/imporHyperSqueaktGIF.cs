imporHyperSqueaktGIF
	"Import the selected file as a GIF file, into the HyperSqueak picture library.  8/17/96 sw"

	model isLocked ifTrue: [^ view flash].

	self controlTerminate.
	model imporHyperSqueaktGIF.
	self controlInitialize