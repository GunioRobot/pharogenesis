openInMVCExtent: extent
	Smalltalk isMorphic ifTrue: [^ self openInWorldExtent: extent].
	self bounds: (16@0 extent: extent).  "Room on left for scroll bars"
	MorphWorldView openWorldWith: self labelled: labelString