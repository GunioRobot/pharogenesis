serviceSortByName
	"Answer a service for soring by name"

	^ (SimpleServiceEntry new
		provider: self label: 'by name' selector: #sortByName 
		description: 'sort entries by name')
		extraSelector: #sortingByName;
		buttonLabel: 'name'