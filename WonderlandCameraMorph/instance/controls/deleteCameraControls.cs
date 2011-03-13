deleteCameraControls
	"Hide the camera controls for the camera rendering into this window"
	(self submorphOfClass: WonderlandCameraControls)
		ifNotNil: [myControls delete.
			myControls _ nil]