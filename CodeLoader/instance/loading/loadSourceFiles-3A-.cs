loadSourceFiles: anArray
	"Load all the source files in the given array."
	| loader request |
	loader _ HTTPLoader default.
	sourceFiles _ anArray collect:[:name|
		request _ self createRequestFor: name in: loader.
		request].
