timeFrom: aString 
	"Parse the date and time and answer the result as the number of seconds 
	since the start of 1980."
	| s t rawDelta delta |
	s _ ReadStream on: aString.
	t _ (self readDateFrom: s) asSeconds.
	"date part"
	[s atEnd or: [s peek isAlphaNumeric]]
		whileFalse: [s next].
	s atEnd ifFalse: ["read time part (interpreted as local, regardless of sender's timezone)"
		t _ t + (Time readFrom: s) asSeconds].
	s skipSeparators.
	('+-' includes: s peek)
		ifTrue: 
			[s peekFor: $+. rawDelta _ Integer readFrom: s.
			delta _ rawDelta // 100 * 60 + (rawDelta \\ 100).
			t _ t - (delta * 60)].
	^ t - (Date newDay: 1 year: 1980) asSeconds"time started with 1980..."