nextDomainLiteral
	| start end |
	start _ pos.
	end _ text indexOf: $] startingAt: start ifAbsent: [ 0 ].
	end = 0 ifTrue: [
		"not specified"
		self error: 'saw [ without a matching ]' ].

	pos _ end+1.

	^MailAddressToken
		type: #DomainLiteral
		text: (text copyFrom: start to: end)