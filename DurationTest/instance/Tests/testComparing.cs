testComparing

	| d1 d2 d3 |
	d1 _ Duration seconds: 10 nanoSeconds: 1.
	d2 _ Duration seconds: 10 nanoSeconds: 1.
	d3 _ Duration seconds: 10 nanoSeconds: 2.
	
	self
		assert: (d1 = d1);
		assert: (d1 = d2);
		deny: (d1 = d3);
		assert: (d1 < d3)
