contentType
	| type i |
	type _ self getHeader: 'content-type' default: nil.
	type ifNil: [ ^nil ].
	type _ type withBlanksTrimmed.
	i _ type indexOf: $;.
	i = 0 ifTrue: [ ^type ].
	^(type copyFrom: 1 to: i-1) withBlanksTrimmed	