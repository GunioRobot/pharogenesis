updateUpdatesList: aString
	"ScriptLoader new updateUpdatesList: 'cleanUpMethods'"
	
	| str |
	str := FileDirectory default oldFileNamed: 'updates.list'.
	[	str
			setToEnd;
			cr;
			nextPutAll: self currentUpdateVersionNumber asString;
			nextPutAll: '-Pha-', aString, '.cs' ]
		ensure: [ str close ]