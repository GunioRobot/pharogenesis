deleteFile: filePath
	FileDirectory splitName: filePath to: [:dirPath :fileName |
		(FileDirectory forFileName: filePath)
			deleteFileNamed: fileName ifAbsent: []].