hasDropShadowString
	^ (self hasDropShadow
		ifTrue: ['<on>']
		ifFalse: ['<off>'])
		, 'show shadow' translated