normalizedSubject: srcString
	"Turn the raw subject line into a decent possible subject filter"

	| res |
	res _ srcString.

	"Remove leading Re:s"
	[res asLowercase beginsWith: 're:']
		whileTrue: [res _ (res copyFrom: 4 to: res size) withBlanksTrimmed].

	^ res