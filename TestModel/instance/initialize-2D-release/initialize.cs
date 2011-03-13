initialize

	super initialize.
	self
		summaryText: String new;
		detailsText: String new;
		failureList: OrderedCollection new;
		errorList: OrderedCollection new;
		patternHistory: OrderedCollection new;
		summaryTextM: nil;
		summaryTextV: nil;
		updateColorSelector: nil;
		patternTextM: nil;
		patternTextV: nil.