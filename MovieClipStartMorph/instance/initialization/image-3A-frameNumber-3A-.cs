image: aForm frameNumber: n

	self image: (aForm magnifyBy: self thumbnailHeight asFloat / aForm height).
	frameNumber _ n.