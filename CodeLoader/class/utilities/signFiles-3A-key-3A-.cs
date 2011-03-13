signFiles: fileNames key: privateKey
	"Sign the files in the current directory and put them into a folder signed."

	|  newNames |
	newNames _ fileNames collect:[:fileName | 'signed', FileDirectory slash, fileName].
	CodeLoader
		signFilesFrom: fileNames
		to: newNames
		key: privateKey