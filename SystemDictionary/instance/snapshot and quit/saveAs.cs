saveAs

	| dir imageSuffix changesSuffix newName newImageName newChangesName |
	dir _ FileDirectory default.
	imageSuffix _ self fileNameEnds first.
	changesSuffix _ self fileNameEnds last.
	newName _ (FillInTheBlank
		request: 'New File Name?'
		initialAnswer: 'NewImageName') asFileName.
	((newName endsWith: imageSuffix) and:
	 [newName size > imageSuffix size]) ifTrue: [
		newName _ newName copyFrom: 1 to: newName size - imageSuffix size - 1].

	newImageName _ newName, FileDirectory dot, imageSuffix.
	newChangesName _ newName, FileDirectory dot, changesSuffix.
	((dir includesKey: newImageName) or:
	 [dir includesKey: newChangesName]) ifTrue: [
		^ self notify: newName, ' is already in use.
Please choose another name.'].

	dir copyFileNamed: self changesName toFileNamed: newChangesName.
	self logChange: '----SAVEAS ', newName, '----', Date dateAndTimeNow printString.
	self imageName: (dir fullNameFor: newImageName).
	LastImageName _ self imageName.
	self closeSourceFiles; openSourceFiles.  "so SNAPSHOT appears in new changes file"
	self snapshot: true andQuit: false.
