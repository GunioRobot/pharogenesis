toggleFileListIndex: anInteger
	"Select the file name in the receiver's list whose index is the argument, 
	anInteger. If the current selection index is already anInteger, deselect it."
	| item name |
	listIndex = anInteger
	ifTrue:
		[listIndex _ 0.
		contents _ ''.
		fileName _ nil]
	ifFalse: 
		[listIndex _ anInteger.
		item _ list at: anInteger.
		item first = $( ifTrue:  "remove size or date"
			[item _ item copyFrom: (item indexOf: $)) + 2 to: item size].
		(item endsWith: self folderString)
			ifTrue:
			["remove [...] folder string and open the folder"
			name _ item copyFrom: 1 to: item size - self folderString size.
			listIndex _ 0.
			^ self directory: (FileDirectory newOnPath:
				(directory fullNameFor: name))]
			ifFalse:
			["open the file selected"
			self setFileName: item]].
	self changed: #fileListIndex