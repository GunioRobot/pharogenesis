assuredCanvas
	(self canvas == nil or:
	 [(self canvas extent ~= self viewBox extent)
		or: [self canvas form depth ~= Display depth]])
		ifTrue:
			["allocate a new offscreen canvas the size of the window"
			self canvas: (Display defaultCanvasClass extent: self viewBox extent)].
	^ self canvas