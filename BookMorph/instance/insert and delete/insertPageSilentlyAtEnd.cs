insertPageSilentlyAtEnd
	"Create a new page at the end of the book.  Do not turn to it."

	| sz newPage bw bc cc | 
	currentPage == nil
		ifTrue: [sz _ pageSize.
			bw _ 0.
			bc _ Color blue muchLighter.
			cc _ color]
		ifFalse: [sz _ currentPage extent.
			bw _ currentPage borderWidth.
			bc _ currentPage borderColor.
			cc _ currentPage color].
	newPagePrototype
		ifNil: [newPage _ PasteUpMorph new extent: sz; color: cc.
			newPage borderWidth: bw; borderColor: bc]
		ifNotNil: [Cursor wait showWhile: 
				[newPage _ newPagePrototype veryDeepCopy]].
	newPage setNameTo: self defaultNameStemForNewPages.
	newPage resizeToFit: false.
	pages isEmpty
		ifTrue: [pages add: (currentPage _ newPage)]	"had been none"
		ifFalse: [pages add: newPage after: pages last].
	^ newPage