getUpdateDirectoryOrNil
	^ (FileDirectory default directoryNames includes: 'updates')
		ifTrue: [FileDirectory default directoryNamed: 'updates']
		ifFalse: [self inform: 'Error: cannot find "updates" folder'.
			nil]