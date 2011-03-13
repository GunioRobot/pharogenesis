browseFile: fileName    "ChangeList browseFile: 'AutoDeclareFix.st'"
	"Opens a changeList on the file named fileName"
	| changesFile changeList |
	changesFile _ FileStream readOnlyFileNamed: fileName.
	Cursor read showWhile:
		[changeList _ self new
			scanFile: changesFile from: 0 to: changesFile size].
	changesFile close.
	self open: changeList name: fileName , ' log'