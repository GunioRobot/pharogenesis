open: aFileName forWrite: writeMode 
	"Open the receiver.  If writeMode is true, allow write, else access will be 
	read-only. "
	| result |
	result _ super open: aFileName forWrite: writeMode.
	result ifNotNil: [self detectLineEndConvention].
	^ result