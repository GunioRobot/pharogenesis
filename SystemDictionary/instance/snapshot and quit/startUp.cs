startUp
	"Start up the low-space watcher and open the files for sources and changes."

	Smalltalk installLowSpaceWatcher.
	self openSourceFiles.