uncacheBits
	super uncacheBits.
	self label ~=  model name ifTrue: [self setLabelTo: model name]