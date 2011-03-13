testSchemeAbsolutePass5
	| uri |
	uri _ URI fromString: 'http://www.squeakland.org#fragment'.
	self should: [uri scheme = 'http'].
	self should: [uri isAbsolute].
	self shouldnt: [uri isOpaque].
	self shouldnt: [uri isRelative].
	self should: [uri fragment = 'fragment'].
