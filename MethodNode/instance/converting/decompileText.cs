decompileText 
	"Answer a string description of the parse tree whose root is the receiver."
	^ Text streamContents: [:strm | self printOn: strm]