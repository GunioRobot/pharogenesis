removeAllCopiesOf: e
	(self occurrencesOf: e) timesRepeat: [self remove: e].