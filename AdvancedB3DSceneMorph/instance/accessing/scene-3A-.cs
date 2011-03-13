scene: aScene
	super scene: (self updateSceneWithDefaults: aScene).
	self updateUpVectorForCamera: self scene defaultCamera.
	self updateHeadlight.
	self changed