startOfArticle: aString
	"Answer the newsgroup name if the given string is the start of a news article, for example:
		Article 2958 of comp.lang.smalltalk:
	Otherwise, answer nil."

	| s name |
	s _ ReadStream on: aString.
	(self nextStringOf: s equals: 'Article ') ifFalse: [^nil].
	[s next isDigit] whileTrue.	"consumes digits plus the following space"
	(self nextStringOf: s equals: 'of ') ifFalse: [^nil].
	name _ s upTo: $:.
	((name size > 1) & (s atEnd)) ifFalse: [^nil].
	^name