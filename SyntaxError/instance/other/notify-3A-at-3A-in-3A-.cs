notify: error at: location in: source
	"Open a syntax error view, inserting the given error message into the given source at the given location. This message is sent to the 'requestor' when the parser or compiler finds a syntax error."

	| aClass aString |
	aClass _ thisContext sender receiver encoder classEncoding.
	aString _
		source contents
			copyReplaceFrom: location
			to: location - 1
			with: error.
	self setClass: aClass
		code: aString
		debugger: (Debugger context: thisContext)
		doitFlag: false.
	self class open: self.
