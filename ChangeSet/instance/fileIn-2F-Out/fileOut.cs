fileOut
	"File out the receiver, to a file whose name is a function of the change-set name and of the date and the time.  1/18/96 sw
 2/4/96 sw: show write cursor
	5/30/96 sw: put a dot before the date/time stamp"

	| file |
	Cursor write showWhile:
		[file _ FileStream newFileNamed: ((self name, '.', Utilities dateTimeSuffix, '.cs') truncateTo: 27).
		file header; timeStamp.
		self fileOutOn: file.
		file trailer; close]