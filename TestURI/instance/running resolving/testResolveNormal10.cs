testResolveNormal10
	| baseURI relURI resolvedURI |
	baseURI := 'http://a/b/c/d;p?q' asURI.
	relURI := 'g?y#s'.
	resolvedURI := baseURI resolveRelativeURI: relURI.
	self should: [resolvedURI asString = 'http://a/b/c/g?y#s'].
