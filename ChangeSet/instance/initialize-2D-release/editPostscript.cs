editPostscript
	"edit the receiver's postscript, in a separate window.  "

	self assurePostscriptExists.
	StringHolderView open: postscript label: 'Postscript for ChangeSet named ', name