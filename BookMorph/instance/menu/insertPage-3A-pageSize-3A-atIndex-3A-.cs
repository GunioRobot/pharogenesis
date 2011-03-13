insertPage: aPage pageSize: aPageSize atIndex: anIndex

	| sz  predecessor |
	sz _ aPageSize
		ifNil: [currentPage == nil
			ifTrue: [pageSize]
			ifFalse: [currentPage extent]]
		ifNotNil:
			[aPageSize].
	aPage extent: sz.
	((pages isEmpty | anIndex == nil) or: [anIndex > pages size])
		ifTrue:
			[pages add: aPage]
		ifFalse:
			[anIndex <= 1
				ifTrue:
					[pages addFirst: aPage]
				ifFalse:
					[predecessor _ anIndex == nil
						ifTrue:
							[currentPage]
						ifFalse:
							[pages at: anIndex].
					self pages add: aPage after: predecessor]].

	self goToPageMorph: aPage
