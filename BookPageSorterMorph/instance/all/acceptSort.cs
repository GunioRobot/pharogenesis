acceptSort

	| pages |
	pages _ OrderedCollection new.
	pageHolder submorphsDo: [:m |
		(m isKindOf: BookPageThumbnailMorph) ifTrue: [pages add: m page]].
	book newPages: pages currentIndex: pageHolder cursor.
	self delete.
