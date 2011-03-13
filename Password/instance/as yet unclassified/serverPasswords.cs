serverPasswords
	"Get the server passwords off the disk.  Decode them.  File 'sqk.info' must be in the same folder with the version of the Squeak application (VM) that is running this image now."

	| raw dir |
	dir _ (SourceFiles at: 1) directory.
	(dir fileExists: 'sqk.info') ifFalse: [^ nil].	"Caller will ask user for password"
	raw _ (dir oldFileNamed: 'sqk.info') contentsOfEntireFile.
		"If you don't have this file, and you really do want to release 
		an update, contact Ted Kaehler."
	^ (self decode: raw) findTokens: String cr.
