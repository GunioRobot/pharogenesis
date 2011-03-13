setUp: named
	| newAction |
	super setUp: named.
	newAction _ PWS actions at: named.
	newAction cacheDirectory: (self defaultCacheDirectory).
	newAction cacheURL: (self defaultCacheURL).
	newAction source: 'cswiki',(ServerAction pathSeparator).
	^ newAction