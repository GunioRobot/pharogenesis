readFrom: aStreamOrFileName
	| stream name eocdPosition |
	stream _ aStreamOrFileName isStream
		ifTrue: [name _ aStreamOrFileName name. aStreamOrFileName]
		ifFalse: [StandardFileStream readOnlyFileNamed: (name _ aStreamOrFileName)].
	stream binary.
	eocdPosition _ self class findEndOfCentralDirectoryFrom: stream.
	eocdPosition <= 0 ifTrue: [self error: 'can''t find EOCD position'].
	self readEndOfCentralDirectoryFrom: stream.
	stream position: eocdPosition - centralDirectorySize.
	self readMembersFrom: stream named: name