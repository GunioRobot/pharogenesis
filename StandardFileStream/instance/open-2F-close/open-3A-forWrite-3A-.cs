open: aFileName forWrite: writeMode 
	"Open the receiver.  If writeMode is true, allow write, else access will be read-only.  2/12/96 sw"
	fileID _ self primOpen: aFileName writable: writeMode.
	fileID == nil ifTrue: [^ nil].
	name _ aFileName.
	rwmode _ writeMode.
	buffer1 _ String new: 1.
	closed _ false