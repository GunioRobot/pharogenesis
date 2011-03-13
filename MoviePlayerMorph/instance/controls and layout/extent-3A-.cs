extent: newExtent

	| tlMargin brMargin pageExtent scale fullSizeImage |
	fullSizeImage _ frameBufferIfScaled ifNil: [currentPage image].
	frameCount ifNil: [^ self].  "Not yet open"
	tlMargin _ currentPage topLeft - self topLeft.
	brMargin _ self bottomRight - currentPage bottomRight.
	pageExtent _ newExtent - brMargin - tlMargin.
	scale _ pageExtent x asFloat / frameSize x min: pageExtent y asFloat / frameSize y.
	(scale _ scale max: 0.25) > 0.9 ifTrue: [scale _ 1.0].

	pageExtent _ (frameSize * scale) rounded.
	pageExtent = frameSize
		ifTrue: [currentPage image: fullSizeImage.
				frameBufferIfScaled _ nil]
		ifFalse: [currentPage image: (Form extent: pageExtent depth: frameDepth).
				frameBufferIfScaled _ fullSizeImage.
				(WarpBlt current toForm: currentPage image) sourceForm: fullSizeImage;
					combinationRule: 3;
					copyQuad: fullSizeImage boundingBox innerCorners
						toRect: currentPage image boundingBox].
	^ self layoutChanged
