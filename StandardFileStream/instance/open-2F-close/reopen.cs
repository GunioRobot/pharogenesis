reopen
	"Reopen the receiver, in the same mode as previously, first closing it if applicable.  1/31/96 sw"

	closed ifFalse: [self close].
	self open: name forWrite: rwmode