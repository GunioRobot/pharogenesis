forBook: aBookMorph 

	^ self book: aBookMorph
		morphsToSort: (aBookMorph pages collect: [:p | p thumbnailForPageSorter])