initialDirectoryList

	| dir nameToShow dirList |
	dirList _ (FileDirectory on: '') directoryNames collect: [ :each |
		FileDirectoryWrapper with: (FileDirectory on: each) name: each model: self].
	dirList isEmpty ifTrue:[
		dirList _ Array with: (FileDirectoryWrapper 
			with: FileDirectory default 
			name: FileDirectory default localName 
			model: self)].
	dirList _ dirList,(
		ServerDirectory serverNames collect: [ :n | 
			dir _ ServerDirectory serverNamed: n.
			nameToShow _ n.
			(dir directoryWrapperClass with: dir name: nameToShow model: self)
				balloonText: dir realUrl
		]
	).
	^dirList