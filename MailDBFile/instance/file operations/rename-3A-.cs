rename: newFileName
	"Rename this file."

	FileDirectory splitName: filename to: [:dirPath :oldFileName |
		(FileDirectory forFileName: filename) 
			rename: oldFileName toBe: newFileName].
	filename _ newFileName.
