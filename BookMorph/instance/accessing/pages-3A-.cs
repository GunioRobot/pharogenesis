pages: aMorphList

	pages _ aMorphList asOrderedCollection.

	"John:  While it is tempting to put this code here, it is wrong.
	pages size > 0
		ifTrue: [currentPage _ pages first]
		ifFalse: [self insertPage].
	If currentPage is not page 1, then when it comes back in, two pages
are shown at once!
	Just trust the copying mechanism and let currentPage be copied
correctly. --Ted."