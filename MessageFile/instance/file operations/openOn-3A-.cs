openOn: aFileName
	"Initialize myself for the message file with the given name."

	filename _ aFileName.
	file _ nil.
	self ensureFileIsOpen.