beginAppend
	"Set the file to the end prior to performing a sequence of basicAppend operations."

	self ensureFileIsOpen.
	file setToEnd.