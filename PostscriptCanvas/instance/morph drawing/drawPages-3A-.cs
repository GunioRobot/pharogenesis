drawPages:collectionOfPages
	| currentPage |
	currentPage _ 0.
	collectionOfPages do:[ :page |
		currentPage _ currentPage + 1.
		target print:'%%Page: '; write:currentPage; space; write:currentPage; cr.
		self drawPage:page.
	].
	target print:'%%Pages: '; write:currentPage; cr.
