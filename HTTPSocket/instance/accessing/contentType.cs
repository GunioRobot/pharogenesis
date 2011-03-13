contentType
	| type i |
	type := self getHeader: 'content-type' default: nil.
	type ifNil: [ ^nil ].
	type := type withBlanksTrimmed.
	i := type indexOf: $;.
	i = 0 ifTrue: [ ^type ].
	^(type copyFrom: 1 to: i-1) withBlanksTrimmed	