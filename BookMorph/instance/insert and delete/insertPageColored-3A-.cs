insertPageColored: aColor
	"Insert a new page for the receiver, using the given color as its background color"

	| sz newPage bw bc |
	currentPage == nil
		ifTrue:
			[sz _ pageSize.
			bw _ 0.
			bc _ Color blue muchLighter]
		ifFalse:
			[sz _ currentPage extent.
			bw _ currentPage borderWidth.
			bc _ currentPage borderColor].
	newPagePrototype
		ifNil:
			[newPage _ PasteUpMorph new extent: sz; color: aColor.
			newPage borderWidth: bw; borderColor: bc]
		ifNotNil: [Cursor wait showWhile: 
				[newPage _ newPagePrototype veryDeepCopy]].
	newPage setNameTo: self defaultNameStemForNewPages.
	newPage resizeToFit: false.
	pages isEmpty
		ifTrue: [pages add: (currentPage _ newPage)]
		ifFalse: [pages add: newPage after: currentPage].
	self nextPage
