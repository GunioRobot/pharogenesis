testResolveAbnormal17
	| baseURI relURI resolvedURI |
	baseURI _ 'http://a/b/c/d;p?q' asURI.
	relURI _ 'g#s/./x'.
	resolvedURI _ baseURI resolveRelativeURI: relURI.
	self should: [resolvedURI asString = 'http://a/b/c/g#s/./x'].
