asColorizedSmalltalk80Text
	"Answer a colorized Smalltalk-80-syntax string description of the parse tree whose root is the receiver."

	^ DialectStream
		dialect: #ST80
		contents: [:strm | self printOn: strm]