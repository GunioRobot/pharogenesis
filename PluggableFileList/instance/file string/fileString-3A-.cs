fileString: aString

	"| textName index ending |
	textName _ aString asString.
	(FileDirectory default fileExists: textName) ifTrue:
		[self directory: (FileDirectory forFileName: textName).
		 index _ list indexOf: (FileDirectory localNameFor: textName).
		 index = 0 ifTrue: 
			[ending _ ') ', (FileDirectory localNameFor: textName).
		  	 index _ list findFirst: [:line | line endsWith: ending]].
		 self fileListIndex: index].
	(FileDirectory default directoryExists: textName) ifTrue:
		[self directory: (FileDirectory on: textName)]."
	self changed: #fileString.
	self changed: #contents.
	^true