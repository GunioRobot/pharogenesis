saveAs
	| dir newName imageSuffix changesSuffix |
	dir _ FileDirectory default.
	imageSuffix _ self fileNameEnds first.
	changesSuffix _ self fileNameEnds last.
	newName _ (FillInTheBlank request: 'New File Name?' 					initialAnswer: 'NewImageName') asFileName.
	(newName endsWith: imageSuffix) ifTrue:
		[newName _ newName copyFrom: 1 to: newName size - imageSuffix size].
	(dir includesKey: newName , imageSuffix)
		| (dir includesKey: newName , changesSuffix) ifTrue:
		[^ self notify: newName , ' is already in use
Please choose another name.'].
	dir copyFileNamed: self changesName toFileNamed: newName , changesSuffix.
	self logChange: '----SAVEAS ' , newName , '----'
		, Date dateAndTimeNow printString.
	self imageName: newName , imageSuffix.
	LastImageName _ self imageName.
	self closeSourceFiles; openSourceFiles.
	"Just so SNAPSHOT appears on the new file, and not the old"
	self snapshot: true andQuit: false.