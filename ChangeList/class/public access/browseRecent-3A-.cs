browseRecent: charCount    "ChangeList browseRecent: 5000"
	"Opens a changeList on the end of the changes log file"
	| changesFile changeList end |
	changesFile _ (SourceFiles at: 2) readOnlyCopy.
	end _ changesFile size.
	Cursor read showWhile:
		[changeList _ self new
			scanFile: changesFile from: (0 max: end-charCount) to: end].
	changesFile close.
	self open: changeList name: 'Recent changes' multiSelect: true