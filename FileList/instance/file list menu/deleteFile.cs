deleteFile
	"Delete the currently selected file"
	listIndex = 0 ifTrue: [^ self].
	(self confirm: 'Really delete ' , fileName , '?') ifFalse: [^ self].
	directory deleteFileNamed: fileName.
	self updateFileList.
	brevityState _ #FileList.
	self get