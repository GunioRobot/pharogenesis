browse
	| file |
	file _ (StandardFileMenu oldFileFrom: self directory) ifNil: [^nil].
	file directory isNil ifTrue: [^ nil].

	textMorph setText: (file directory pathName, FileDirectory slash, file name);
		hasUnacceptedEdits: true;
		accept