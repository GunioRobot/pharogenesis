openFileList
	Preferences useFileList2
		ifTrue: [ FileList2 prototypicalToolWindow openInWorld: myWorld ]
		ifFalse: [ FileList prototypicalToolWindow openInWorld: myWorld ]