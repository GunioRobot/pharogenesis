serverPasswords
	"Get the server passwords off the disk and decode them. The file 'sqk.info' must be in the same folder as the Squeak application (VM) that is running this image. (Note: This code works even if you are running with no system sources file.)"

	| dir encodedPasswords |
	dir _ FileDirectory on: Smalltalk vmPath.
	(dir fileExists: 'sqk.info') ifFalse: [^ nil].	"Caller will ask user for password"
	encodedPasswords _ (dir readOnlyFileNamed: 'sqk.info') contentsOfEntireFile.
		"If you don't have this file, and you really do want to release 
		an update, contact Ted Kaehler."
	^ (self decode: encodedPasswords) findTokens: String cr
