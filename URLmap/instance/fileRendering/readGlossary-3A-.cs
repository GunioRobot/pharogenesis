readGlossary: aStream
	|aLine pieces name url newpage|
	"Expect a CR-delimited file of 'pageName' and 'URL' separated by
vertical bars '|'"
	self pages: (Dictionary new).
	aStream open.
	[aStream atEnd] whileFalse:
		[aLine := aStream upTo: (Character cr).
		pieces _ aLine findTokens: '|'.
		name _ pieces at: 1.
		url _ pieces at: 2.
		newpage _ SwikiPage new.
		newpage coreID: url.
		newpage map: self.
		newpage name: name.
		pages at: name asLowercase put: newpage].
	aStream close.


	