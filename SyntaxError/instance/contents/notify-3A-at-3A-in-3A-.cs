notify: error at: location in: source
	"Put up a SyntaxError window in the normal way.  And we know the category.  TK 15 May 96."
	"Open a standard system view whose model is an instance of me. The syntax error occurred in typing to add code, aString, to class, aClass. "
	| topView aListView aCodeView aClass aString |
	aClass _ thisContext sender receiver encoder classEncoding.
	aString _ (source contents
							copyReplaceFrom: location
							to: location - 1
							with: error).
	self setClass: aClass
		code: aString
		debugger: (Debugger context: thisContext).
	self class open: self