initialize
	"SARInstaller initialize"
	(FileList respondsTo: #registerFileReader:)
		ifTrue: [ FileList registerFileReader: self ]