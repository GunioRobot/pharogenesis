updateLists

	self failureList: (self result failures collect: [:failure |
		failure printString]).
	self errorList: (self result errors collect: [:error |
		error printString]).