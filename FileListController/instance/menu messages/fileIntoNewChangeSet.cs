fileIntoNewChangeSet
	"File in the selected file into a new change set.  7/12/96 sw"

	model isLocked ifTrue: [^ view flash].

	self controlTerminate.
	model fileIntoNewChangeSet.
	self controlInitialize