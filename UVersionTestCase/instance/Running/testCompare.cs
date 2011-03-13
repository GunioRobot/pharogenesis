testCompare
	self should: [ (UVersion readFromString: '1') < (UVersion readFromString: '2') ].
	self should: [ (UVersion readFromString: '1.5.7') < (UVersion readFromString: '1.5.8') ].
	self should: [ (UVersion readFromString: '1.5.7') < (UVersion readFromString: '1.6.2') ].
	self should: [ (UVersion readFromString: '1.5') < (UVersion readFromString: '1.5a') ].
	self should: [ (UVersion readFromString: '1.5a') < (UVersion readFromString: '1.5b') ].
	self should: [ (UVersion readFromString: '1.5b') < (UVersion readFromString: '1.6') ].