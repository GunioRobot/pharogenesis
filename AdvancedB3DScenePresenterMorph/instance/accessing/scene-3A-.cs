scene: aScene
	super scene:  aScene.
	self updateUpVectorForCamera: self scene defaultCamera.
"	self updateHeadlight. "
	self changed