make: newURLString relativeTo: oldURLString 
	"Local file refs are not handled well, so work around here"
	^((oldURLString includesSubString: '://') not
		and: [(newURLString includesSubString: '://') not])
		ifTrue: [oldURLString , (UnixFileDirectory localNameFor: newURLString)]
		ifFalse: [(newURLString asUrlRelativeTo: oldURLString asUrl) toText]