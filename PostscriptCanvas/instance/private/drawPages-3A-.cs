drawPages:collectionOfPages
	collectionOfPages do:[ :page |
		pages _ pages + 1.
		target print:'%%Page: '; write:pages; space; write:pages; cr.
		self drawPage:page.
	].
	morphLevel = 0 ifTrue: [ self writeTrailer: pages ].