recordFrameRate: fps
	frameRate _ fps.
	fps > 0.0 ifTrue:[stepTime _ (1000.0 / fps) rounded].
	player stepTime: stepTime.