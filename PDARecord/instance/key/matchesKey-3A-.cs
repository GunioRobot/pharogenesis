matchesKey: aString

	key ifNil: [^ true].  "unkeyed items show up as 'all' "
	(aString = 'all' or: [key = 'all']) ifTrue: [^ true].
	^ key = aString