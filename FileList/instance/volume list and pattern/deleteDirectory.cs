deleteDirectory
	"Remove the currently selected directory"
	| localDirName |
	directory entries size = 0 ifFalse:[^self inform:'Directory must be empty'].
	localDirName _ directory localName.
	(self confirm: 'Really delete ' , localDirName , '?') ifFalse: [^ self].
	self volumeListIndex: self volumeListIndex-1.
	directory deleteDirectory: localDirName.
	self updateFileList.