initializeIconFromGIFNamed: aString
	"Make the receiver be an iconic button with its picture derived from a form found in GIFImports.  Not currently in use, and was somewhat flawed. "
	| aForm image |
	aForm _ GIFImports at: aString ifAbsent: [self halt].
	self removeAllMorphs.
	self extent: aForm extent.
	self addMorphCentered: (image _ ImageMorph new image: aForm).
	self color: Color yellow.
	self flag: #deferred.
	self setBorderWidth: 2 borderColor: Color yellow.
	"image lock"