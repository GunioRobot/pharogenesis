spotChanged

	self invalidRect:
		((spotBuffer offset extent: spotBuffer extent) "intersect: self bounds")