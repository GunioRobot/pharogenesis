pathDirString
	"Path to directory as url, using slash as delimiter"

	^ String streamContents: [ :s |
		1 to: self path size - 1 do: [ :ii |
			s nextPutAll: (path at: ii); nextPut: $/
			 ] ]