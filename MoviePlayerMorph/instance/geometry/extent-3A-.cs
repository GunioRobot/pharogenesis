extent: newExtent

	| tlMargin brMargin pageExtent scale fullSizeImage |
	fullSizeImage := frameBufferIfScaled ifNil: [currentPage image].
	frameCount ifNil: [^ self].  "Not yet open"
	tlMargin := currentPage topLeft - self topLeft.
	brMargin := self bottomRight - currentPage bottomRight.
	pageExtent := newExtent - brMargin - tlMargin.
	scale := pageExtent x asFloat / frameSize x min: pageExtent y asFloat / frameSize y.
	(scale := scale max: 0.25) > 0.9 ifTrue: [scale := 1.0].

	pageExtent := (frameSize * scale) rounded.
	pageExtent = frameSize
		ifTrue: [currentPage image: fullSizeImage.
				frameBufferIfScaled := nil]
		ifFalse: [currentPage image: (Form extent: pageExtent depth: frameDepth).
				frameBufferIfScaled := fullSizeImage.
				(WarpBlt current toForm: currentPage image) sourceForm: fullSizeImage;
					combinationRule: 3;
					copyQuad: fullSizeImage boundingBox innerCorners
						toRect: currentPage image boundingBox].
	^ self layoutChanged
