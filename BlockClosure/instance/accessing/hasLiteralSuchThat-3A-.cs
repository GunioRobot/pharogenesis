hasLiteralSuchThat: testBlock

	(testBlock value: method) ifTrue: [^ true].
	^ method hasLiteralSuchThat: testBlock