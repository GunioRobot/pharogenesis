assertVars: ivars subsumeAll: primList
	| summum |
	summum _ Set new.
	primList valuesDo: [:vars | summum addAll: vars].
	summum removeAll: ivars.
	summum isEmpty ifFalse: [self error: 'unexpected variables in primitive: ' , summum printString].