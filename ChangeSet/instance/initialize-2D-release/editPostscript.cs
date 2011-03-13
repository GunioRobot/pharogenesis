editPostscript
	"edit the receiver's postscript, in a separate window.  "

	self assurePostscriptExists.
	postscript openLabel: 'Postscript for ChangeSet named ', name