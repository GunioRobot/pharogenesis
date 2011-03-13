browseStream: changesFile
	"Opens a changeList on a fileStream"
	| changeList |

	changesFile readOnly.
	Cursor read showWhile:
		[changeList _ self new
			scanFile: changesFile from: 0 to: changesFile size].
	changesFile close.
	self open: changeList name: changesFile localName , ' log' multiSelect: true