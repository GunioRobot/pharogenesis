scanFrom: aFile
	"Read my name off the file for this page.  Other pages contain a ref to me like *myName* "

	aFile setToEnd.
	self backupAChunk: aFile.
	"extract the name"
	Compiler evaluate: (aFile nextChunk) for: self logged: false.
	map at: name asLowercase put: self.
	aFile close.