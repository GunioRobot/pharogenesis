primitiveRename: oldFileName toBe: newFileName 
	"Rename the file of the given name if it exists, else fail"
	<primitive: 159>
	self halt: 'Attempt to rename a non-existent file,
or to use a name that is already in use'