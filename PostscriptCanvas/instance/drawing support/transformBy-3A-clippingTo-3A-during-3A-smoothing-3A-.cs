transformBy: aDisplayTransform clippingTo: aClipRect during: aBlock smoothing: cellSize

	| retval |
	self comment:'drawing clipped ' with:aClipRect.
	self comment:'drawing transformed ' with:aDisplayTransform.
     self gsave.
	aClipRect ifNotNil:[ self rect:aClipRect; clip].
	self transformBy:aDisplayTransform.
	retval _ aBlock value:self.
     self grestore.	
	self comment:'end of drawing clipped ' with:aClipRect.
	^ retval
