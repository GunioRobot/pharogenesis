serviceSortByDate
	"Answer a service for sorting by date"

	^  (SimpleServiceEntry new
			provider: self 
			label: 'by date' 
			selector: #sortByDate 
			description: 'sort entries by date')
		extraSelector: #sortingByDate;
		buttonLabel: 'date'