initialize
"
	self initialize
"

	| tt |
	Smalltalk addToShutDownList: TTCFont.
	tt _ TTFontDescription default.
	tt ifNotNil: [self newTextStyleFromTT: tt].

	(FileList respondsTo: #registerFileReader:) ifTrue: [
		FileList registerFileReader: self
	].
