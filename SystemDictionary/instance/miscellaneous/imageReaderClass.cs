imageReaderClass
	"Answer, if present, a class to handle the importing of various graphic image files
	from disk. If none, return nil.   tao 10/26/97"

	| aClass |
	^ ((aClass _ self at: #ImageReadWriter ifAbsent: [nil]) isKindOf: Class)
		ifTrue:
			[aClass]
		ifFalse:
			[nil]