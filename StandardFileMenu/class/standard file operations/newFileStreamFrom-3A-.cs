newFileStreamFrom: aDirectory

	| sfmResult fileStream |
	sfmResult _ self newFileFrom: aDirectory.
	sfmResult ifNil: [^nil].
	fileStream _ sfmResult directory newFileNamed: sfmResult name.
	[fileStream isNil] whileTrue:
		[sfmResult _ self newFileFrom: aDirectory.
		sfmResult ifNil: [^nil].
		fileStream _ sfmResult directory newFileNamed: sfmResult name].
	^fileStream
