processFile
	"Read and process the entire file"
	super processFile.
	player loadInitialFrame.
	^player