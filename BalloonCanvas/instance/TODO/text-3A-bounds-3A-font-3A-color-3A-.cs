text: s bounds: boundsRect font: fontOrNil color: c
	(self ifNoTransformWithIn: boundsRect)
		ifTrue:[^super text: s bounds: boundsRect font: fontOrNil color: c]