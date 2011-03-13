copyMovieFrom: firstFrame to: lastFrame
	| copy newFrame |
	copy := super copyMovieFrom: firstFrame to: lastFrame.
	copy reset.
	copy visible: false atFrame: 0.
	firstFrame to: lastFrame do:[:i|
		newFrame := i - firstFrame + 1.
		copy visible: (self visibleAtFrame: i) atFrame: newFrame.
		copy matrix: (self matrixAtFrame: i) atFrame: newFrame.
		copy depth: (self depthAtFrame: i) atFrame: newFrame.
		copy colorTransform: (self colorTransformAtFrame: i) atFrame: newFrame.
	].
	^copy