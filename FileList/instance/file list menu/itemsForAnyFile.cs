itemsForAnyFile
	^ #(('copy name to clipboard' 'rename' 'delete' 'compress')
		()
		(copyName renameFile deleteFile compressFile)
		)