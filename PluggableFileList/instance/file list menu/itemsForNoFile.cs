itemsForNoFile
	^ #(
		('sort by name' 'sort by size' 'sort by date'
		'add new file' 'add new directory')
		(3)
		(sortByName sortBySize sortByDate
		addNewFile addNewDirectory)
		)