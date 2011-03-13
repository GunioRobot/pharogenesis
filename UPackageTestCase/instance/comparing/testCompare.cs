testCompare
	self should: [ p1 = p2 ].
	self should: [ p1 hash = p2 hash ].

	p2 homepage: 'http://www.squeakland.org' asUrl.
	self shouldnt: [ p1 = p2 ].

	p2 homepage: p1 homepage.
	self should: [ p1 = p2 ].
	self should: [ p1 hash = p2 hash ].

	p1 homepage: nil.
	p2 homepage: nil.
	self should: [ p1 = p2 ].
	self should: [ p1 hash = p2 hash ].

	p2 maintainer: 'Jane'.
	self shouldnt: [ p1 = p2 ].