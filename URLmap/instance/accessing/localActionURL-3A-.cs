localActionURL: aString
	|string|
	"fake up a more ordinary URL by dropping the shriek chars"
	string _ aString copyWithout: $!.
	^'<a href="',string,'">',string,'</a>'