loadRotScalePics
	"Load up class vars with .bmp files for the images of the Rotation control button and the Scale control button.  File names do not change."
	"	self loadRotScalePics		"

	rotationTabForm _ Form fromBMPFileNamed: 'Rotaball.bmp' depth: 16.
	scaleTabForm _ Form fromBMPFileNamed: 'Scalball.bmp' depth: 16.
	
	