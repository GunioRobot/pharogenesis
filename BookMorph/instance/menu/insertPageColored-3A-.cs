insertPageColored: aColor

	| sz newPage |
	currentPage == nil
		ifTrue: [sz _ pageSize]
		ifFalse: [sz _ currentPage extent].
	newPage _ BookPageMorph new extent: sz; color: aColor.
	"newPage setNameTo: self externalName, ' page'."
	pages isEmpty
		ifTrue: [pages add: (currentPage _ newPage)]
		ifFalse: [pages add: newPage after: currentPage].
	self nextPage.
