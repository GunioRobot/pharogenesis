toggleCameraControls
	myControls == nil
		ifTrue:[self showCameraControls]
		ifFalse:[self deleteCameraControls].