decompileString 
	"Answer a string description of the parse tree whose root is the receiver."
	^ String streamContents: [:strm | self printOn: strm]