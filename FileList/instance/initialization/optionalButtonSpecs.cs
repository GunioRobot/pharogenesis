optionalButtonSpecs
	^ #(	
		('Name' 		sortByName				sortingByName	'sort entries by name')
		('Date'			sortByDate				sortingByDate	'sort entries by date')
		('Size'			sortBySize				sortingBySize	'sort entries by size')
		('Changes'		browseChanges			none			'open a changelist browser on selected file')
		('File-in'		fileInSelection			none			'fileIn the selected file')
		('File-in to New'	fileIntoNewChangeSet	none			'fileIn the selected file into a new change set')
		('Delete'			deleteFile				none			'delete the seleted item'))
