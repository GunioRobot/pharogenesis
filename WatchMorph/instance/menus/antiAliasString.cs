antiAliasString
	^ (antialias
		ifTrue: ['<on>']
		ifFalse: ['<off>'])
		, 'anti-aliasing' translated