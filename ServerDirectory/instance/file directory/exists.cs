exists
	"It is difficult to tell if a directory exists.  This is ugly, but it works for writable directories.  (tested only for file://)"

	| probe |
	self entries size > 0 ifTrue: [^ true].
	(probe _ self newFileNamed: 'withNoName23') ifNil: [^ false].
	probe close.
	probe directory deleteFileNamed: probe localName.
	^ true