reload
	"Reload the map from the latest checkpoint on disk.
	The opposite of #purge."

	| fname stream map |
	fname _ self lastCheckpointFilename.
	fname ifNil: [self error: 'No checkpoint available!'].
	stream _ (self directory oldFileNamed: fname) asUnZippedStream.
	stream ifNil: [self error: 'Couldn''t open stream on checkpoint file!'].
	stream converter: Latin1TextConverter new.
	[map _ (stream reset fileInObjectAndCode) install arrayOfRoots first] ensure: [stream close].
	self copyFrom: map