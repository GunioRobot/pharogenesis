reset
	self removeAllKeyFrameData.
	self matrix: MatrixTransform2x3 identity atFrame: 0.
	self visible: false atFrame: 0.
	self depth: 0 atFrame: 0.
	self ratio: 0.0 atFrame: 0.
	self visible: true.
