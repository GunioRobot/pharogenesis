oldFileNamed: aFileName 
 	"Open a file in the default directory (or in the directory contained
	in the input arg); by default, it's available for reading.  2/12/96 sw
	Prior contents will be overwritten, but not truncated on close.  3/18 di"

	(self isAFileNamed: aFileName) ifFalse:
		[(self confirm: 'Could not find ' , (self localNameFor: aFileName) , '.
Do you want to create it?')
			ifFalse: [self halt]].
	^ self new open: aFileName forWrite: true