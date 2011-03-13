testSchemeAbsolutePass2
	| uri |
	uri _ URI fromString: 'mailto:somebody@somewhere.nowhere'.
	self should: [uri scheme = 'mailto'].
	self should: [uri isAbsolute].
	self should: [uri isOpaque].
	self shouldnt: [uri isRelative]