noteInterestOf: client inAll: classes
	lock critical: [interests addAll: classes].