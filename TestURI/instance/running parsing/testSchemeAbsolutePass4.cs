testSchemeAbsolutePass4
	| uri |
	uri := URI fromString: 'mailto:somebody@somewhere.nowhere#fragment'.
	self should: [uri scheme = 'mailto'].
	self should: [uri isAbsolute].
	self should: [uri isOpaque].
	self shouldnt: [uri isRelative].
	self should: [uri fragment = 'fragment'].
