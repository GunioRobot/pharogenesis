userInitials: aString

	userInitials _ aString.
	bounds _ bounds merge: (bounds topRight + (0@4) extent: (userInitials asParagraph extent)).
