toggleListIndex: index
	"Select the volume name in the receiver's list whose index is the argument."

	| delim path |
	volListIndex _ index.
	delim _ directory pathNameDelimiter.
	path _ String streamContents: [:strm |
		2 to: index do: [:i |
			strm nextPutAll: (volList at: i).
			i < index ifTrue: [strm nextPut: delim]]].
	self directory: (FileDirectory on: path).
