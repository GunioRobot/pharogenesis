showCameraControls
	"Show the camera controls for the camera rendering into this window"

	myControls ifNil: [
			myControls _ WonderlandCameraControls newFor: myCamera.
			self addMorph: myControls.
					  ].

	myControls show.
