saveAs

	| dir newName newImageName newChangesName newImageSegDir oldImageSegDir haveSegs |
	dir _ FileDirectory default.
	newName _ FillInTheBlank
		request: 'New File Name?'
		initialAnswer: (FileDirectory localNameFor: self imageName).
	newName = '' ifTrue: [^self].
	newName _ FileDirectory baseNameFor: newName asFileName.

	newImageName _ newName, FileDirectory dot, FileDirectory imageSuffix.
	newChangesName _ newName, FileDirectory dot, FileDirectory changeSuffix.
	((dir includesKey: newImageName) or:
	 [dir includesKey: newChangesName]) ifTrue: [
		^ self notify: newName, ' is already in use.
Please choose another name.'].

	dir copyFileNamed: self changesName toFileNamed: newChangesName.
	
	"On Mac, set the file type and creator (noop on other platforms)"
	FileDirectory default
		setMacFileNamed: newChangesName
		type: 'STch'
		creator: 'FAST'.

	haveSegs _ false.
	Smalltalk at: #ImageSegment ifPresent: [:theClass | 
		(haveSegs _ theClass instanceCount ~= 0) ifTrue: [
			oldImageSegDir _ theClass segmentDirectory]].

	self logChange: '----SAVEAS ', newName, '----', Date dateAndTimeNow printString.
	self imageName: (dir fullNameFor: newImageName).
	LastImageName _ self imageName.
	self closeSourceFiles; openSourceFiles.  "so SNAPSHOT appears in new changes file"
	haveSegs ifTrue: [
		Smalltalk at: #ImageSegment ifPresent: [:theClass |
			newImageSegDir _ theClass segmentDirectory.	"create the folder"
			oldImageSegDir fileNames do: [:theName | "copy all segment files"
				newImageSegDir 
					copyFileNamed: oldImageSegDir pathName, FileDirectory slash, theName 
					toFileNamed: theName]]].
	self snapshot: true andQuit: false.
