insertLineFeeds
	"(FileStream oldFileNamed: 'BBfix2.st') insertLineFeeds"
	| s crLf f |
	crLf := String with: Character cr with: (Character value: 10).
	s := (self next: self size) readStream.
	self close.
	f := FileStream newFileNamed: self name.
	[s atEnd] whileFalse: 
		[f nextPutAll: (s upTo: Character cr); nextPutAll: crLf].
	f close