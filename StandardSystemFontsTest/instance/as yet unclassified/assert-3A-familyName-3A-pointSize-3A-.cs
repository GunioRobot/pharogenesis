assert: selector familyName: aString pointSize: anInteger

	| font |
	font _ Preferences perform: selector.
	self assert: font familyName = aString.
	self assert: font pointSize = anInteger
	