testCurrent

	| yyyy |

	yyyy _ DateAndTime now year.
	
	self assert: Year current start = (DateAndTime year: yyyy month: 1 day: 1)