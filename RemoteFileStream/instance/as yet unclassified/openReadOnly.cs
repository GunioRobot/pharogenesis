openReadOnly
	"If we have data, don't reread.  Is this OK????"

	self readOnly.
	readLimit _ readLimit max: position.
	readLimit > 0 ifFalse: [remoteFile getFileNamed: remoteFile fileName into: self]. 