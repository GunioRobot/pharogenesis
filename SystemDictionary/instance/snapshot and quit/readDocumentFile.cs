readDocumentFile
	"Process system updates. Read a document file, if one was provided. Start application."

	| fileName object |
	StartupStamp _ '----STARTUP----', Time dateAndTimeNow printString, ' as ', Smalltalk imageName.
	self processUpdates.
	fileName _ Smalltalk getSystemAttribute: 2.
	((fileName ~~ nil) and: [fileName size > 0])
		ifTrue: [
			(fileName asLowercase beginsWith: 'http://')
				ifTrue: [
					"fetch remote file"
					HTTPSocket httpFileIn: fileName]
				ifFalse: [
					"read local file"
					object _ (FileStream oldFileNamed: fileName) fileInObjectAndCode.

					"if launching a .sqo document, send open to the final object"
					(fileName endsWith: '.sqo') ifTrue: [object open]]]
		ifFalse: [
			(Preferences valueOfFlag: #startImagineeringStudio)
				ifTrue: [ScriptingSystem openImagineeringStudio]].
