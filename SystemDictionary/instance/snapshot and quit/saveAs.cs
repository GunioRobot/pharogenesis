saveAs
	| dir newName |
	dir _ FileDirectory default.
	newName _ (FillInTheBlank request: 'New File Name?' 					initialAnswer: 'NewImageName') asFileName.
	(newName endsWith: '.image') ifTrue:
		[newName _ newName copyFrom: 1 to: newName size - 6].
	(dir includesKey: newName , '.image')
		| (dir includesKey: newName , '.changes') ifTrue:
		[^ self notify: newName , ' is already in use
Please choose another name.'].
	dir copyFileNamed: self changesName toFileNamed: newName , '.changes'.
	self logChange: '----SAVEAS ' , newName , '----'
		, Date dateAndTimeNow printString.
	self imageName: newName , '.image'.
	self closeSourceFiles; openSourceFiles.
	"Just so SNAPSHOT appears on the new file, and not the old"
	self snapshot: true andQuit: false.