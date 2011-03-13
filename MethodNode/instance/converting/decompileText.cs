decompileText 
	"Answer a string description of the parse tree whose root is the receiver."

	^ DialectStream
		dialect: (Preferences printAlternateSyntax ifTrue: [#SQ00] ifFalse: [#ST80])
		contents: [:strm | self printOn: strm]