readFrom: strm  "MultiSymbol readFromString: '#abc'"

	strm peek = $# ifFalse: [self error: 'MultiSymbols must be introduced by #'].
	^ (Scanner new scan: strm) advance  "Just do what the code scanner does"
