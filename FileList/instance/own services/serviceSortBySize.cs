serviceSortBySize
	"Answer a service for sorting by size"

	^  (SimpleServiceEntry 
			provider: self 
			label: 'by size' 
			selector: #sortBySize
			description: 'sort entries by size')
				extraSelector: #sortingBySize;
				buttonLabel: 'size'