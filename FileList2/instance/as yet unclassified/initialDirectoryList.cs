initialDirectoryList

	| dir nameToShow |
	^ 
	((FileDirectory on: '') directoryNames collect: [ :each |
		FileDirectoryWrapper with: (FileDirectory on: each) name: each model: self
	]),
	(
		ServerDirectory serverNames collect: [ :n | 
			dir _ ServerDirectory serverNamed: n.
			nameToShow _ n.
			(dir directoryWrapperClass with: dir name: nameToShow model: self)
				balloonText: dir realUrl
		]
	)
