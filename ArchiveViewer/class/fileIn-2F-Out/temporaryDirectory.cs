temporaryDirectory
	"Answer a directory to use for unpacking files for the file list services."
	^FileDirectory default directoryNamed: '.archiveViewerTemp'