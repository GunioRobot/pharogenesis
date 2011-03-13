fullName
	"Answer the full name to be used to identify the current code author."

	[fullName isEmptyOrNil ] whileTrue: [self requestFullName].
	^ fullName