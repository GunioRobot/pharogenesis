getCameraControls
	myControls == nil ifTrue:[
		self showCameraControls.
		self hideCameraControls.
	].
	^myControls