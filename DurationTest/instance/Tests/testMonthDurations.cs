testMonthDurations

	| jan feb dec |
	jan _ Duration month: #January.
	feb _ Duration month: #February.
	dec _ Duration month: #December.
	
	self 
		assert: jan = (Year current months first duration);
		assert: feb = (Year current months second duration);
		assert: dec = (Year current months last duration)

		
