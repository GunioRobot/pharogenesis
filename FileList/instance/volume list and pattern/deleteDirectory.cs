deleteDirectory
	"Remove the currently selected directory"
	| localDir |
	directory entries size = 0 ifFalse:[^self inform:'Directory must be empty'].
	localDir _ directory pathParts last.
	(self confirm: 'Really delete ' , localDir printString , '?') ifFalse: [^ self].
	self volumeListIndex: self volumeListIndex-1.
	directory deleteDirectory: localDir.
	self updateFileList.