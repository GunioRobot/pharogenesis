def: nth for: partOfSpeech

	| ii strm |
	parts ifNil: [self parts].
	(ii _ parts indexOf: partOfSpeech) = 0 ifTrue: [^ nil].
	strm _ partStreams at: ii.
	strm reset.
	1 to: nth do: [:nn | 
		strm match: '<BR>',(String with: Character lf),nn printString, '.  '.
		strm match: ' -- '].
	^ strm upToAll: '<BR>'