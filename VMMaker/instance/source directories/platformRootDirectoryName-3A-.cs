platformRootDirectoryName: aString
	"set the directory where we should find all platform's sources
	There really ought to be plausible sanity checks done here"
	platformRootDirName _ aString.
	(FileDirectory default directoryExists: aString) ifFalse:[self couldNotFindDirectory: aString. ^false].
	self reinitializePluginsLists.
	^true