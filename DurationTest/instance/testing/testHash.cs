testHash
	self assert: aDuration hash =    	(Duration days: 1 hours: 2 minutes: 3 seconds: 4 nanoSeconds: 5) hash.
	self assert: aDuration hash =     93789
	"must be a more meaningful test?"