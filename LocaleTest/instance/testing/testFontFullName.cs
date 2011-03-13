testFontFullName
	"self debug: #testFontFullName"
	| env dir |
	env := (Locale isoLanguage: 'ja') languageEnvironment.
	dir := FileDirectory on: SecurityManager default untrustedUserDirectory.
	[dir recursiveDelete]
		on: Error
		do: [:e | e].
	env fontFullName.
	self assert: dir exists