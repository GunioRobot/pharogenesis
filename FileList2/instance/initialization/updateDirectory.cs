updateDirectory
	"directory has been changed externally, by calling directory:.
	Now change the view to reflect the change."
	self changed: #currentDirectorySelected.
	self postOpen.