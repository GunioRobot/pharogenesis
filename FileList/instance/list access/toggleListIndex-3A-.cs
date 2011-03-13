toggleListIndex: index
	"Select the volume name in the receiver's list whose index is the argument."
	| delim name |
	volListIndex _ index.
	delim _ directory pathNameDelimiter.
	name _ volList at: index.
	self directory: (FileDirectory newOnPath: 
			(String streamContents: 
					[:strm | 2 to: index do:
						[:i | strm nextPutAll: (volList at: i).
						i < index ifTrue: [strm nextPut: delim]]])).