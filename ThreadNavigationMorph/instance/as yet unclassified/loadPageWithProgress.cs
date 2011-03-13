loadPageWithProgress

	ComplexProgressIndicator new 
		targetMorph: self;
		historyCategory: 'project loading';
		withProgressDo: [self loadPage]
