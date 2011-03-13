newFrame: frameChangeBlock
	self reframeTo: (self windowBox newRectFrom:
		[:f | self constrainFrame: (frameChangeBlock value: f)])