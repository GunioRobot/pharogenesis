readOnlyFileNamed: aFileName
	"Open a file of the given name for read-only access.  1/31/96 sw"
	| f |
	f _ self new open: aFileName forWrite: false.
	f == nil ifTrue: [self halt: 'Could not find ' , (self localNameFor: aFileName)].
	^ f