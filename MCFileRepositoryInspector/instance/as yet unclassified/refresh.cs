refresh
	| name latest av |
	versions _ repository readableFileNames collect: [ :each |
		name _ each copyUpToLast: $..
		name last isDigit ifFalse: [Array with: name with: '' with: '' with: each]
			ifTrue:
				[Array
					with: (name copyUpToLast:  $-)
					with: ((name copyAfterLast: $-) upTo: $.)
					with: ((name copyAfterLast: $-) copyAfter: $.)
					with: each]].
	newer _ Set new.
	older _ Set new.
	loaded _ MCWorkingCopy allManagers 
		inject: Set new
		into: [ :result :each |
			each ancestors do: [ :ancestor |
				result add: ancestor name , '.mcz'].
			each ancestry allAncestors do: [:ea | older add: (ea name, '.mcz')].
			latest _ (versions select: [:v | v first = each package name])	
				detectMax: [:v | v third asNumber].
			(latest notNil and: [
				each ancestors allSatisfy: [:ancestor |
					av _ ((ancestor name copyAfterLast: $-) copyAfter: $.) asNumber.
					av < latest third asNumber or: [
						av = latest third asNumber and: [ancestor name, '.mcz' ~= latest fourth]]]])
				ifTrue: [newer add: each package name ].
			result ].
	self changed: #packageList; changed: #versionList