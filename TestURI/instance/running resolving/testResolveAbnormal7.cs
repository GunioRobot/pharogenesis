testResolveAbnormal7
	| baseURI relURI resolvedURI |
	baseURI _ 'http://a/b/c/d;p?q' asURI.
	relURI _ 'g..'.
	resolvedURI _ baseURI resolveRelativeURI: relURI.
	self should: [resolvedURI asString = 'http://a/b/c/g..'].
