reload
	"Reload the map from the latest checkpoint on disk.
	The opposite of #purge."

	| fname stream map |
	fname := self lastCheckpointFilename.
	fname ifNil: [self error: 'No checkpoint available!'].
	"Code below uses good ole StandardFileStream to avoid m17n issues (this is binary data) and
	also uses #unzipped since it works in older Squeaks"
	stream := (StandardFileStream oldFileNamed: (self directory fullNameFor: fname)) asUnZippedStream.
	"stream := (RWBinaryOrTextStream with: contents) reset."
	stream ifNil: [self error: 'Couldn''t open stream on checkpoint file!'].
	[map := (stream fileInObjectAndCode) install arrayOfRoots first] ensure: [stream close].
	self copyFrom: map