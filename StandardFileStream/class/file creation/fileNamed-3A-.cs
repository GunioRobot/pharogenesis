fileNamed: aFileName 
 	"Open a file in the default directory (or in the directory contained
	in the input arg); by default, it's available for writing.  2/12/96 sw
	Prior contents will be overwritten, but not truncated on close.  3/18 di"

	^ self new open: aFileName forWrite: true