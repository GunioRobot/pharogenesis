fileIndex
	"Answer the index of the sources file on which this method is stored, as follows:
		1:	.sources file
		2:	.changes file
		3 and 4 are also available for future extension of source code management"

	self last < 252 ifTrue: [^ 0  "no source"].
	^ self last - 251

	