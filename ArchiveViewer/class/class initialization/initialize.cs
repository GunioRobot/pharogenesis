initialize
	"ArchiveViewer initialize"

	FileList registerFileReader: self.
	Smalltalk addToShutDownList: self.