setFileStream: aStream
	"Used to initialize a spawned file editor.  Sets directory too."

	self directory: aStream directory.
	fileName _ aStream localName.
	pattern _ '*'.
	listIndex _ 1.  "pretend a file is selected"
	aStream close.
	brevityState _ #needToGetBrief.
	self changed: #contents.
