testResolveNormal7
	| baseURI relURI resolvedURI |
	baseURI _ 'http://a/b/c/d;p?q' asURI.
	relURI _ '?y'.
	resolvedURI _ baseURI resolveRelativeURI: relURI.
	self should: [resolvedURI asString = 'http://a/b/c/?y'].
