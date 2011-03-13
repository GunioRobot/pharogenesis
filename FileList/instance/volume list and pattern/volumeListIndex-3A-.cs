volumeListIndex: index
	"Select the volume name having the given index."

	| delim path |
	volListIndex _ index.
	delim _ directory pathNameDelimiter.
	path _ String streamContents: [:strm |
		2 to: index do: [:i |
			strm nextPutAll: (volList at: i) withBlanksTrimmed.
			i < index ifTrue: [strm nextPut: delim]]].
	self directory: (directory on: path).
	brevityState _ #FileList.
	self changed: #fileList.
	self changed: #contents.
