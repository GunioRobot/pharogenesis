pixelHeight
	"In Morphic the receiver will have been given a code font, in MVC the font will be nil. So when the font is nil, answer the pixelHeight of the MVC Browsers' code font, i.e. TextStyle defaultFont pixelHeight"
	^(font ifNil:[TextStyle defaultFont]) pixelSize