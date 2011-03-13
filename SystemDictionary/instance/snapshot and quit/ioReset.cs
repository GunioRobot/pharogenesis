ioReset    "Smalltalk ioReset"
	"Cause a shutDown and startUp of OS resources.
	This can be useful to close hung files so that they
	can be opened again, as when a fileOut failed"

	self processShutDownList.
	self garbageCollect.  "Purge unref'd files"
	self processStartUpList