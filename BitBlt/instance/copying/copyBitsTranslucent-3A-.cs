copyBitsTranslucent: factor
	"This entry point to BitBlt supplies an extra argument to specify translucency
	for operations 30 and 31.  The argument must be an integer between 0 and 255."

	<primitive: 'primitiveCopyBits' module: 'BitBltPlugin'>

	"Check for compressed source, destination or halftone forms"
	((sourceForm isKindOf: Form) and: [sourceForm unhibernate])
		ifTrue: [^ self copyBitsTranslucent: factor].
	((destForm isKindOf: Form) and: [destForm unhibernate])
		ifTrue: [^ self copyBitsTranslucent: factor].
	((halftoneForm isKindOf: Form) and: [halftoneForm unhibernate])
		ifTrue: [^ self copyBitsTranslucent: factor].

	self primitiveFailed  "Later do nicer error recovery -- share copyBits recovery"