delete
	"Delete this file."

	FileDirectory splitName: filename to: [:dirPath :name |
		(FileDirectory forFileName: filename) 
			deleteFileNamed: name ifAbsent: []].
