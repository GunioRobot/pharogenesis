specsForProjectLoader
	^ #(	
('Name' 		sortByName				sortingByName	'sort entries by name')
('Date'			sortByDate				sortingByDate	'sort entries by date')
('Size'			sortBySize				sortingBySize	'sort entries by size')
('Load'			openProjectFromFile		none			'load the selected project')
	)
