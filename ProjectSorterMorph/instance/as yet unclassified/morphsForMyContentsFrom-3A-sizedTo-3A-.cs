morphsForMyContentsFrom: listOfPages sizedTo: sz

	| morphsForPageSorter |

	'Assembling thumbnail images...'
		displayProgressAt: self cursorPoint
		from: 0 to: listOfPages size
		during: [:bar |
			morphsForPageSorter _ listOfPages withIndexCollect: [ :each :index | 
				bar value: index.
				self sorterMorphForProjectNamed: each first
			].
		].
	^morphsForPageSorter
