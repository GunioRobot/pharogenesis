writeStackText: stacks in: resourceDirectory registerIn: aCollector
	"The user's text is very valuable.  Write an extra file with just the text.  It can be read in case the Project can't be opened." 
	"Find allText for each stack, storeOn a local file in the resources folder, with a name like myProj.005.myStack.t.  Make the names be unique."

	"get project name and version"
	| localName sn trial char ind fs resourceURL textLoc |
	resourceURL _ self resourceUrl.
	stacks do: [:stackObj |	"Construct a good file name"
		localName _ self versionedFileName allButLast: 2.	"projectName.005."
		stacks size = 1 ifFalse: ["must distinguish between stacks in the project"
			(sn _ stackObj knownName) ifNil: [
				sn _ stackObj hash printString].	"easy name, or use hash"
			localName _ localName , sn, FileDirectory dot]. 	"projectName.005.myStack."
		localName _ localName , 't'.
		"See if in use because truncates same as another, fix last char, try again"
		[trial _ resourceDirectory checkName: localName fixErrors: true.
		 trial endsWith: '.t'] whileFalse: [
				localName _ (localName allButLast: 3) , FileDirectory dot, 't'].
		[resourceDirectory fileExists: trial] whileTrue: [
			char _ trial at: (ind _ trial size - 3).
			trial at: ind put: (char asciiValue + 1) asCharacter].	"twiddle it a little"
		
		"write allText in file"
		fs _ resourceDirectory newFileNamed: trial.
		fs timeStamp; cr; nextPutAll: '''This is the text for a stack in this project.  Use only in an emergency, if the project file is ever unreadable.''.'; cr; cr.
		stackObj getAllText storeOn: fs.    fs close.
		textLoc _ (ResourceLocator new) localFileName: trial; 
			urlString: resourceURL, '/', trial.
		aCollector locatorMap at: trial "any distinct object" put: textLoc.
		].