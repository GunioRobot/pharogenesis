loadSourceFiles: anArray
	"Load all the source files in the given array."
	| loader request |
	loader := HTTPLoader default.
	sourceFiles := anArray collect:[:name|
		request := self createRequestFor: name in: loader.
		request].
