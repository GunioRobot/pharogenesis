thoroughWhichSelectorsReferTo: literal special: specialFlag byte: specialByte
	"Answer a set of selectors whose methods access the argument as a 
	literal. Dives into the compact literal notation, making it slow but 
	thorough "

	| who |
	who _ Set new.
	self selectorsAndMethodsDo:
		[:sel :method |
		((method hasLiteralThorough: literal) or: [specialFlag and: [method scanFor: specialByte]])
			ifTrue:
				[((literal isMemberOf: Association) not
					or: [method sendsToSuper not
					or: [method literals allButLast includes: literal]])
						ifTrue: [who add: sel]]].
	^ who