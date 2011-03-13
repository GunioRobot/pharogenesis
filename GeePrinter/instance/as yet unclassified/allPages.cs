allPages

	| pageNumber allPages maxPages |

	maxPages _ 9999.
	pageNumber _ 0.
	allPages _ self pageRectangles collect: [ :rect |
		pageNumber _ pageNumber + 1.
		(self as: GeePrinterPage) pageNumber: pageNumber bounds: rect
	].
	allPages size > maxPages ifTrue: [allPages _ allPages first: maxPages].
	allPages do: [ :each | each totalPages: allPages size].
	^allPages

