testReset

	| sw |
	sw _ Stopwatch new.
	sw activate.
	
	sw reset.
	self 
		assert: (sw isSuspended);
		assert: (sw timespans isEmpty)
