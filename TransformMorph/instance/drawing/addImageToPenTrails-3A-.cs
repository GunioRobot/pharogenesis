addImageToPenTrails: aForm 
	| canvas |
	owner
		ifNil: [^ self].
	canvas := Display defaultCanvasClass extent: self extent depth: Display depth.
	canvas
		translateBy: self topLeft negated
		during: [:tempCanvas | tempCanvas
				transformBy: transform
				clippingTo: self innerBounds
				during: [:myCanvas | myCanvas drawImage: aForm at: aForm offset]
				smoothing: smoothing].
	owner
		addImageToPenTrails: (canvas form offset: self topLeft)