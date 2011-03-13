sortByDate
	"Resort the list of files"
	model isLocked ifTrue: [^view flash].
	self controlTerminate.
	model sortByDate.
	self controlInitialize