testQuotient

	| d1 d2 q |
	d1 _ 11.5 seconds.
	d2 _ d1 // 3.
	self assert: d2 = (Duration seconds: 3 nanoSeconds: 833333333).

	q _ d1 // (3 seconds).
	self assert: q = 3.

