openFromDirectory: aDirectory andFileName: aFileName

	| fileAndDir |

	ComplexProgressIndicator new 
		targetMorph: nil;
		historyCategory: 'project loading';
		withProgressDo: [
			ProgressNotification signal: '1:foundMostRecent'.
			fileAndDir _ self bestAccessToFileName: aFileName andDirectory: aDirectory.
			self 
				openName: aFileName 
				stream: fileAndDir first 
				fromDirectory: fileAndDir second
				withProjectView: nil.
		]