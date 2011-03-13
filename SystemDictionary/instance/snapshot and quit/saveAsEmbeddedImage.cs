saveAsEmbeddedImage

	| dir newName newImageName newImageSegDir oldImageSegDir haveSegs |
	dir _ FileDirectory default.
	newName _ FillInTheBlank
		request: 'Select existing VM file'
		initialAnswer: (FileDirectory localNameFor: '').
	newName = '' ifTrue: [^self].
	newName _ FileDirectory baseNameFor: newName asFileName.

	newImageName _ newName.
	(dir includesKey: newImageName) ifFalse: [
		^ self notify: 'Unable to find name ',newName, ' Please choose another name.'].

	haveSegs _ false.
	Smalltalk at: #ImageSegment ifPresent: [:theClass | 
		(haveSegs _ theClass instanceCount ~= 0) ifTrue: [
			oldImageSegDir _ theClass segmentDirectory]].

	self logChange: '----SAVEAS ', newName, '----', Date dateAndTimeNow printString.
	self imageName: (dir fullNameFor: newImageName).
	LastImageName _ self imageName.
	self closeSourceFiles.
	haveSegs ifTrue: [
		Smalltalk at: #ImageSegment ifPresent: [:theClass |
			newImageSegDir _ theClass segmentDirectory.	"create the folder"
			oldImageSegDir fileNames do: [:theName | "copy all segment files"
				newImageSegDir 
					copyFileNamed: oldImageSegDir pathName, FileDirectory slash, theName 
					toFileNamed: theName]]].
	self snapshot: true andQuit: true embedded: true.
