getMacFileTypeAndCreator: fileName 
	| results typeString creatorString |
	"get the Macintosh file type and creator info for the file with the given name. Fails if the file does not exist or if the type and creator type arguments are not strings of length 4. Does nothing on other platforms (where the underlying primitive is a noop)."
	"FileDirectory default getMacFileNamed: 'foo'"

	typeString _ ByteArray new: 4 withAll: ($? asInteger).
	creatorString _ ByteArray new: 4 withAll: ($? asInteger).
	[self primGetMacFileNamed: (self fullNameFor: fileName) asVmPathName
		type: typeString
		creator: creatorString.] ensure: 
		[typeString _ typeString asString. 
		creatorString _ creatorString asString].
	results _ Array with: typeString convertFromSystemString with: creatorString convertFromSystemString.
	^results
