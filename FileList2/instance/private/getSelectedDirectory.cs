getSelectedDirectory
	ok == true ifFalse: [^ nil].
	^ currentDirectorySelected
