selectPrecedingIdentifier
	"Invisibly select the identifier that ends at the end of the selection, if any."

	| string sep stop tok |
	tok _ false.
	string _ paragraph text string.
	stop _ self stopIndex - 1.
	[stop > 0 and: [(string at: stop) isSeparator]] whileTrue: [stop _ stop - 1].
	sep _ stop.
	[sep > 0 and: [(string at: sep) tokenish]] whileTrue: [tok _ true. sep _ sep - 1].
	tok ifTrue: [self selectInvisiblyFrom: sep + 1 to: stop]