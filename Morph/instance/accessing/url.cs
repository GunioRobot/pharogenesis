url
	"If I have been assigned a url, return it.  For PasteUpMorphs mostly."
	| sq |
	(sq _ self sqkPage) ifNotNil: [^ sq url].
	^ self valueOfProperty: #url
		