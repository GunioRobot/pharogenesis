pathForDirectory
	"Path using local file system's delimiter.  $\ or $:"

	^ String streamContents: [ :s |
		1 to: self path size - 1 do: [ :ii |
			s nextPutAll: (path at: ii); nextPut: FileDirectory default pathNameDelimiter
			 ] ]