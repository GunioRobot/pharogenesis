whichSelectorsReferTo: literal special: specialFlag byte: specialByte
	"Answer a set of selectors whose methods access the argument as a literal."
	| who method methodArray |
	who _ Set new.
	methodDict associationsDo:
		[:assn |
		method _ assn value.
		((method pointsTo: literal "faster than hasLiteral:") or:
				[specialFlag and: [method scanFor: specialByte]])
			ifTrue:
			[((literal isKindOf: Association) not
				or: [method sendsToSuper not
					or: [(method literals copyFrom: 1
						to: method numLiterals-1)
							includes: literal]])
				ifTrue: [who add: assn key]]].
	^who