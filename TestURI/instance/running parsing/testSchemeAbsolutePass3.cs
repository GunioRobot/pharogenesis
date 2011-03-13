testSchemeAbsolutePass3
	| uri |
	uri _ URI fromString: 'ftp://ftp@squeak.org'.
	self should: [uri scheme = 'ftp'].
	self should: [uri isAbsolute].
	self shouldnt: [uri isOpaque].
	self shouldnt: [uri isRelative].
	self should: [uri userInfo = 'ftp'].
	self should: [uri host = 'squeak.org'].
	self should: [uri port isNil].
