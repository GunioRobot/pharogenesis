asAltSyntaxText 
	"Answer a string description of the parse tree whose root is the receiver, using the alternative syntax"

	^ DialectStream
		dialect: #SQ00
		contents: [:strm | self printOn: strm]