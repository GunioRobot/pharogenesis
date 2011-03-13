testResolveNormal1
	| baseURI relURI resolvedURI |
	baseURI _ 'http://a/b/c/d;p?q' asURI.
	relURI _ 'g:h'.
	resolvedURI _ baseURI resolveRelativeURI: relURI.
	self should: [resolvedURI asString = 'g:h'].
