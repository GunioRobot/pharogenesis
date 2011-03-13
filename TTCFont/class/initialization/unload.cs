unload

	(FileList respondsTo: #unregisterFileReader:) ifTrue: [
		FileList unregisterFileReader: self
	]