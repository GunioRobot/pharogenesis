setSourcePosition: position inFile: fileIndex 
	"Store the location of the source code for the receiver in the receiver. The 
	location consists of which source file (*.sources or *.changes) and the 
	position in that file."

	fileIndex > 4 ifTrue: [^ self error: 'invalid file number'].
	self at: self size put: 251 + fileIndex.
	1 to: 3 do: 
		[:i | self at: self size - i put: ((position bitShift: (i-3)*8) bitAnd: 16rFF)].
