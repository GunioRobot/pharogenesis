altText: aString
	"set the text to be displayed while downloading"
	altText _ aString.
	aString ifNotNil: [self setBalloonText: aString].
	self setContents