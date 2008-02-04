initialize
"
	self initialize
"

	| tt |
	Smalltalk addToShutDownList: TTCFont.
	tt := TTFontDescription default.
	tt ifNotNil: [self newTextStyleFromTT: tt].

	(FileList respondsTo: #registerFileReader:) ifTrue: [
		FileList registerFileReader: self
	].
