testSeconds
	self assert: aDuration seconds =   (800000001/200000000).
	self assert: (Duration  nanoSeconds: 2) seconds = (2/1000000000).	
	self assert: (Duration  seconds: 2) seconds = 2.	
	self assert: (Duration  days: 1 hours: 2 minutes: 3 seconds:4) seconds = (4).
	self deny: (Duration  days: 1 hours: 2 minutes: 3 seconds:4) seconds = (1*24*60*60+(2*60*60)+(3*60)+4).	