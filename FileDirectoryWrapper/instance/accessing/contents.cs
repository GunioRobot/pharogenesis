contents

	^((model directoryNamesFor: item) sortBy: [ :a :b | a caseInsensitiveLessOrEqual: b]) collect: [ :n | 
		FileDirectoryWrapper with: (item directoryNamed: n) name: n model: self
	]
