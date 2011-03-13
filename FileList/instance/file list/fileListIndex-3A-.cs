fileListIndex: anInteger
	"Select the file name having the given index, and display its contents."

	| item name |
	self okToChange ifFalse: [^ self].
	listIndex _ anInteger.
	listIndex = 0 
		ifTrue: [fileName _ nil]
		ifFalse:
			[item _ self fileNameFromFormattedItem: (list at: anInteger).
			(item endsWith: self folderString)
				ifTrue:
					["remove [...] folder string and open the folder"
					name _ item copyFrom: 1 to: item size - directory folderString size.
					listIndex _ 0.
					self changed: #closeScrollBar.  "will write in pane to left (MVC)"
					self directory: (directory directoryNamed: name).
					brevityState _ #FileList.
					^ self changed: #contents]
				ifFalse: [fileName _ item]].  "open the file selected"

	brevityState _ #needToGetBrief.
	self changed: #fileListIndex.
	self changed: #contents.
