storeLocallyWithProgressInfo

	ComplexProgressIndicator new 
		targetMorph: nil;
		historyCategory: 'project storing';
		withProgressDo: [self storeLocallyInnards]
	