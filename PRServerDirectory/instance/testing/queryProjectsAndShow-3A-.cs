queryProjectsAndShow: thingsToSearchForCollection 
	"query the server for all the projects that match  
	thingsToSearchForCollection"
	| url arguments answer string |
	url := self urlFromServer: self server directories: {'programmatic'. 'queryprojects'}.
	arguments := self getPostArgsFromThingsToSearchFor: thingsToSearchForCollection.
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