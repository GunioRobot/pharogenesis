entries
	"Return a list of the files here.  Later use the whole directory info with dates, sizes, times, etc."

	^ self getDirectory contentsOfEntireFile findTokens: FTPSocket crLf.
	