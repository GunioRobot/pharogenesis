addNewVersionBasedOn: aVersion

	| tmp |
	(versions includes: aVersion) ifFalse: [^self error: 'Version is not in this history'].

	tmp := aVersion next.
	(versions includes: tmp) ifFalse: 
		[versions add: tmp.
		^tmp].

	tmp := aVersion.
	[versions includes: (tmp := tmp branchNext)] whileTrue.
	versions add: tmp.
	^tmp
	