keys
	^self protected:[
		Array streamContents:[:s| valueDictionary keysDo:[:key| s nextPut: key]]].