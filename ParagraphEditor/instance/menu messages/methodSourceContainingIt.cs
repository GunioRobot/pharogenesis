methodSourceContainingIt
	"Open a browser on methods which contain the current selection in their source (case-sensitive full-text search of source).   EXTREMELY slow!"

	self lineSelectAndEmptyCheck: [^ self].
	(self confirm: 'This will take a few minutes.
Shall I proceed?') ifFalse: [^ self].
	self systemNavigation browseMethodsWithSourceString: self selection string