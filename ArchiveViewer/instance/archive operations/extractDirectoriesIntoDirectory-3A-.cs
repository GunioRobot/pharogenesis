extractDirectoriesIntoDirectory: directory 
	(self members select: [:ea | ea isDirectory]) 
		do: [:ea | ea extractInDirectory: directory]