decompileString 
	"Answer a string description of the parse tree whose root is the receiver."

	^ (DialectStream dialect: #ST80 contents: [:strm | self printOn: strm])
		asString
