loadRotScalePics
	"Load up class vars with .bmp files for the images of the Rotation control button and the Scale control button."

	rotationTabForm _ (Form fromBMPFileNamed: 'Rotaball.bmp') asFormOfDepth: 16.
	scaleTabForm _ (Form fromBMPFileNamed: 'Scalball.bmp') asFormOfDepth: 16.
