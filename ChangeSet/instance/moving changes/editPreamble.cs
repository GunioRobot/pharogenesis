editPreamble
	"edit the receiver's preamble, in a separate window.  "

	self assurePreambleExists.
	preamble openLabel: 'Preamble for ChangeSet named ', name