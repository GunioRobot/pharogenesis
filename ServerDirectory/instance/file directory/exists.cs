exists
	"It is difficult to tell if a directory exists.  This is ugly, but it works for writable directories.  http: will fall back on ftp for this"

	| probe success |
	success _ false.
	self isTypeFile ifTrue: [
		self entries size > 0 ifTrue: [^ true].
		probe _ self newFileNamed: 'withNoName23'. 
		probe ifNotNil: [
			probe close.
			probe directory deleteFileNamed: probe localName].
		^success _ probe notNil].
	[client := self openFTPClient.
	[client pwd]
		ensure: [self quit].
		success := true]
		on: Error
		do: [:ex | ].
	^success