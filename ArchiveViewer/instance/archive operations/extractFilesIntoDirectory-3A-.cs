extractFilesIntoDirectory: directory 
	(self members reject: [:ea | ea isDirectory]) 
		do: [:ea | ea extractInDirectory: directory]