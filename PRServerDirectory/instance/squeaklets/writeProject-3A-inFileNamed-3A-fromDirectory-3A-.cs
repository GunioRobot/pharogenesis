writeProject: aProject inFileNamed: fileNameString fromDirectory: localDirectory 
	"write aProject (a file version can be found in the file named  
	fileNameString in localDirectory)"
	| url arguments answer string |
	url := self urlFromServer: self server directories: {'programmatic'. 'uploadproject'}.
	
	arguments := self
				getPostArgsFromProject: aProject
				fileNamed: fileNameString
				fromDirectory: localDirectory.
	""
	Cursor read
		showWhile: [""
			"answer := HTTPClient httpPostDocument: url args:  
			args."
			answer := HTTPSocket httpGetDocument: url args: arguments.
			string := answer contents.
			(string beginsWith: '--OK--')
				ifTrue: [^ true]].
	""
	self
		inform: ('Server responded: {1}' translated format: {string}).
	^ false