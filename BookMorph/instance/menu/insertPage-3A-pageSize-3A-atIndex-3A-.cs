insertPage: aPage pageSize: aPageSize atIndex: anIndex

	| sz  predecessor |
	self flag: #deferred.  "Presently only called for TabbedPaletteComplexes, but could conceivably call this from insertPage-like methods, after maybe some fixup"
	sz _ aPageSize
		ifNil: [currentPage == nil
			ifTrue: [pageSize]
			ifFalse: [currentPage extent]]
		ifNotNil:
			[aPageSize].
	aPage extent: sz.
	((pages isEmpty | anIndex == nil) or: [anIndex > pages size])
		ifTrue:
			[pages add: (currentPage _ aPage)]
		ifFalse:
			[anIndex == 1
				ifTrue:
					[pages addFirst: aPage]
				ifFalse:
					[predecessor _ anIndex == nil
						ifTrue:
							[currentPage]
						ifFalse:
							[pages at: anIndex].
					self pages add: aPage after: predecessor]].

	self nextPage
