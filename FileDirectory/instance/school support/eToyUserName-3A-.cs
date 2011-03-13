eToyUserName: aString
	"Set the default directory from the given user name"
	| dirName |
	dirName := self eToyBaseFolderSpec. "something like 'U:\Squeak\users\*-Squeak'"
	dirName ifNil:[^self].
	dirName := dirName copyReplaceAll:'*' with: aString.
"	dirName last = self class pathNameDelimiter ifFalse:[dirName := dirName, self slash].
	FileDirectory setDefaultDirectoryFrom: dirName.
	dirName := dirName copyFrom: 1 to: dirName size - 1.

"	pathName := FilePath pathName: dirName