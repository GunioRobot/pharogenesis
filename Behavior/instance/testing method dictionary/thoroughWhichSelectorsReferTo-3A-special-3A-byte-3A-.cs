thoroughWhichSelectorsReferTo: literal special: specialFlag byte: specialByte
	"Answer a set of selectors whose methods access the argument as a literal.  Dives into the compact literal notation, making it slow but thorough"
	| who method |
	who _ Set new.
	methodDict associationsDo:
		[:assn |
		method _ assn value.
		((method hasLiteralSuchThat: [:lit | lit == literal]) or:
				[specialFlag and: [method scanFor: specialByte]])
			ifTrue:
			[((literal isMemberOf: Association) not
				or: [method sendsToSuper not
					or: [method literals allButLast includes: literal]])
				ifTrue: [who add: assn key]]].
	^ who