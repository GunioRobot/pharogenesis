oldFileStreamFrom: aDirectory

	| sfmResult fileStream |
	sfmResult _ self oldFileFrom: aDirectory.
	sfmResult ifNil: [^nil].
	fileStream _ sfmResult directory oldFileNamed: sfmResult name.
	[fileStream isNil] whileTrue:
		[sfmResult _ self oldFileFrom: aDirectory.
		sfmResult ifNil: [^nil].
		fileStream _ sfmResult directory oldFileNamed: sfmResult name].
	^fileStream
