sensesFor: partOfSpeech

	| ii strm |
	parts ifNil: [self parts].
	(ii _ parts indexOf: partOfSpeech) = 0 ifTrue: [^ nil].
	strm _ partStreams at: ii.
	strm reset.
	strm match: '"', word, '"'.
	strm match: ' has '.
	^ (strm upTo: Character lf) asNumber