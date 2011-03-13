addNewDirectory
	self 
		addNew: 'Directory'
		byEvaluating: [:newName | directory createDirectory: newName]
