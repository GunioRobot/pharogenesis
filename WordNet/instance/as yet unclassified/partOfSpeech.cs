partOfSpeech

	rwStream ifNil: [self stream].
	rwStream reset.
	rwStream match: '<BR>The <B>'.
	^ rwStream upToAll: '</B>'