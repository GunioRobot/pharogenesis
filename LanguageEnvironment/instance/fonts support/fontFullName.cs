fontFullName
	"(Locale isoLanguage: 'ja') languageEnvironment fontFullName"
	| dir |
	dir := FileDirectory on: SecurityManager default untrustedUserDirectory.
	"dir exists is needed if it is in restricted mode"
	dir exists
		ifFalse: [dir assureExistence].
	^ dir fullNameFor: self fontFileName