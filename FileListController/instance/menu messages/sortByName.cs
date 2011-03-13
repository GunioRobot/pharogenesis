sortByName
	"Resort the list of files"
	model isLocked ifTrue: [^view flash].
	self controlTerminate.
	model sortByName.
	self controlInitialize