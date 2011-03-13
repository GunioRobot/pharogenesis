defaultAction
	Log ifNotNil: [:log| log add: self].
	Preferences showDeprecationWarnings ifTrue:
		[Transcript nextPutAll: self messageText; cr; flush].
	Preferences raiseDeprecatedWarnings ifTrue:
		[super defaultAction]