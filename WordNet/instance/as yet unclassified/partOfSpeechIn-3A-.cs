partOfSpeechIn: aStrm

	aStrm reset.
	aStrm match: '<BR>The <B>'.
	^ aStrm upToAll: '</B>'