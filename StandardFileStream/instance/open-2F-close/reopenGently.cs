reopenGently
	"Forked processes may not get closed properly during a snapshot.  Reopen it allowing for the fact that the variable closed if false, but the file is really closed."

	self primCloseGentle: fileID.
	closed _ true.
	self open: name forWrite: rwmode