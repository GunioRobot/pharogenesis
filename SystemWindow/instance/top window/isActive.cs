isActive
	self activeOnlyOnTop ifTrue: [^ self == TopWindow].
	^ true