oneEndIs: aVertex
	^(self origin asPoint = aVertex asPoint or: [self destination asPoint = aVertex asPoint])