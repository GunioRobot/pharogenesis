itemsForNoFile
	^ #(
		('sort by name' 'sort by size' 'sort by date'
		'browse code files'
		'add new file' 'add new directory')
		(3 4)
		(sortByName sortBySize sortByDate
		browseFiles
		addNewFile addNewDirectory)
		)