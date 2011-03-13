recordFrameRate: fps
	frameRate := fps.
	fps > 0.0 ifTrue:[stepTime := (1000.0 / fps) rounded].
	player stepTime: stepTime.