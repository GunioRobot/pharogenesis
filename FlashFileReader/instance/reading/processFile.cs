processFile
	"Read and process the entire file"
	self processHeader ifFalse:[^nil].
	self processFileContents.