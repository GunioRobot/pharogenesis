insertPageColored: aColor 
	"Insert a new page for the receiver, using the given color as its background color"

	| sz newPage bw bc |
	bc := currentPage isNil 
				ifTrue: 
					[sz := pageSize.
					bw := 0.
					Color blue muchLighter]
				ifFalse: 
					[sz := currentPage extent.
					bw := currentPage borderWidth.
					currentPage borderColor].
	newPagePrototype ifNil: 
			[newPage := (PasteUpMorph new)
						extent: sz;
						color: aColor.
			newPage
				borderWidth: bw;
				borderColor: bc]
		ifNotNil: [Cursor wait showWhile: [newPage := newPagePrototype veryDeepCopy]].
	newPage setNameTo: self defaultNameStemForNewPages.
	newPage vResizeToFit: false.
	pages isEmpty 
		ifTrue: [pages add: (currentPage := newPage)]
		ifFalse: [pages add: newPage after: currentPage].
	self nextPage