contents: c notifying: n
	| result |
	result _ super contents: c notifying: n.
	result == true ifTrue:
		[self reformulateList].
	^ result