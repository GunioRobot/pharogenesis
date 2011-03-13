gifReaderClass
	"Answer, if present, a class to handle the importing of GIF files from disk. If none, return nil.   9/18/96 sw"

	| aClass |
	^ ((aClass _ self at: #GIFReadWriter ifAbsent: [nil]) isKindOf: Class)
		ifTrue:
			[aClass]
		ifFalse:
			[nil]