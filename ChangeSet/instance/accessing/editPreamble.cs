editPreamble
	"edit the receiver's preamble, in a separate window.  "

	self assurePreambleExists.
	StringHolderView open: preamble label: 'Preamble for ChangeSet named ', name