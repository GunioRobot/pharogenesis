rename: oldFileName toBe: newFileName
	"Rename the file of the given name to the new name. Fail if there is no file of the old name or if there is an existing file with the new name."

	^ self primRename: (self fullNameFor: oldFileName)
				     to: (self fullNameFor: newFileName) 
