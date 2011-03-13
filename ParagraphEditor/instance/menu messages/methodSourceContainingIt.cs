methodSourceContainingIt
	"Open a browser on methods which contain the current selection in their source (case-sensitive full-text search of source).   EXTREMELY slow!"

	startBlock = stopBlock ifTrue: [view flash.  ^ self].
	(PopUpMenu confirm: 'This will take a few minutes.
Shall I proceed?') ifFalse: [^ self].
	Smalltalk browseMethodsWithSourceString: self selection string