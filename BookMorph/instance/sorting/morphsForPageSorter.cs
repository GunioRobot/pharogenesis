morphsForPageSorter
	| i thumbnails |
	'Assembling thumbnail images...'
		displayProgressAt: self cursorPoint
		from: 0 to: pages size
		during:
			[:bar | i _ 0.
			thumbnails _ pages collect:
				[:p | bar value: (i_ i+1).
				pages size > 40 
					ifTrue: [p smallThumbnailForPageSorter inBook: self]
					ifFalse: [p thumbnailForPageSorter inBook: self]]].
	^ thumbnails