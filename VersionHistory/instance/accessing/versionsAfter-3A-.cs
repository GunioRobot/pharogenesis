versionsAfter: aVersion
	"Answer all the versions immediately following aVersion."

	| answer tmp |
	answer := Set new.
	tmp := aVersion next.
	(versions includes: aVersion next) ifTrue: [answer add: tmp].

	tmp := aVersion.
	[versions includes: (tmp := tmp branchNext)] whileTrue:
		[answer add: tmp].
	^answer