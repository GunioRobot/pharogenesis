CSForLastUpdate: aString
	"ScriptLoader new CSForLastUpdate: 'cleanUpMethods'"
	
	| str updateNumber filename|
	updateNumber := self getLatestUpdateNumber.
	filename := updateNumber asString, '-Pha-', aString, '.cs'.
	str := FileDirectory default 
				forceNewFileNamed:  filename.
	self 
		generateCS: self latestScriptLoaderPackageIdentificationString
		fromUpdate: updateNumber on: str.
	str close.
	^ filename