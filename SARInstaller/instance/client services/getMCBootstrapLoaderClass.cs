getMCBootstrapLoaderClass
	^Smalltalk at: #MCBootstrapLoader
		ifAbsent: 
			[(self memberNamed: 'MCBootstrapLoader.st') 
				ifNotNilDo: [:m | self fileInMemberNamed: m.
					Smalltalk at: #MCBootstrapLoader ifAbsent: []]]