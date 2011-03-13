matchesKey: aString andMatchesDate: aDate
	"May be overridden for efficiency"
	^ (self matchesKey: aString) and: [self matchesDate: aDate]