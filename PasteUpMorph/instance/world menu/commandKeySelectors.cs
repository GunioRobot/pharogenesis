commandKeySelectors
	"Answer my command-key table"

	| aDict |
	aDict _ self valueOfProperty: #commandKeySelectors ifAbsentPut: [self initializeDesktopCommandKeySelectors].
	^ aDict