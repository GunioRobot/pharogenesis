eToyUserName: aString
	"Set the default directory from the given user name"
	| dirName |
	dirName _ self eToyBaseFolderSpec. "something like 'U:\Squeak\users\*-Squeak'"
	dirName ifNil:[^self].
	dirName _ dirName copyReplaceAll:'*' with: aString.
"	dirName last = self class pathNameDelimiter ifFalse:[dirName _ dirName, self slash].
	FileDirectory setDefaultDirectoryFrom: dirName.
	dirName _ dirName copyFrom: 1 to: dirName size - 1.

"	pathName _ FilePath pathName: dirName