allFileNames
	^self allFullFileNames collect: [ :ea | self directory localNameFor: ea ]