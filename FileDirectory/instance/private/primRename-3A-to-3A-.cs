primRename: oldFileFullName to: newFileFullName 
	"Rename the file of the given name to the new name. Fail if there is no file of the old name or if there is an existing file with the new name."

	<primitive: 159>
	self error:
'Attempt to rename a non-existent file,
or to use a name that is already in use'.
