selector: aSymbol
	"Set the selector to be associated with the receiver.  Store it in the receiver's command, if appropriate"

	selector _ aSymbol.
	self updateSelectorDisplay