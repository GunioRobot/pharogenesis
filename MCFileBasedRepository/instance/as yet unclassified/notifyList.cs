notifyList
	| list |
	(self allFileNames includes: 'notify') ifFalse: [^ #()].
	^ self readStreamForFileNamed: 'notify' do:
		[:s |
		s upToEnd withSqueakLineEndings findTokens: (String with: Character cr)]