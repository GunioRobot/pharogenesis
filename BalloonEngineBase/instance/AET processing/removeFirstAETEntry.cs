removeFirstAETEntry
	| index |
	self inline: false.
	index _ self aetStartGet.
	self aetUsedPut: self aetUsedGet - 1.
	[index < self aetUsedGet] whileTrue:[
		aetBuffer at: index put: (aetBuffer at: index + 1).
		index _ index + 1.
	].