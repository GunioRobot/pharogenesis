recoverDB
	"Open a mail database with the given root file name."

	(self confirm:
'The mail database named:
    ', rootFilename, '
appears to be damaged.
Shall I fix it?  (This might take some time)')
		ifFalse: [self release. ^nil].

	self openDB.
	Cursor execute showWhile: [self compact].