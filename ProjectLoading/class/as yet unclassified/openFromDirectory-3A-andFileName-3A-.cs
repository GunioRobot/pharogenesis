openFromDirectory: aDirectory andFileName: aFileName

	ComplexProgressIndicator new 
		targetMorph: nil;
		historyCategory: 'project loading';
		withProgressDo: [
			ProjectLoading 
				openFromFile: (aDirectory oldFileNamed: aFileName) 
				fromDirectory: aDirectory
				withProjectView: nil.
		]