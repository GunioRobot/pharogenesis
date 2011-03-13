sortBySize
	"Resort the list of files"
	model isLocked ifTrue: [^view flash].
	self controlTerminate.
	model sortBySize.
	self controlInitialize