isSafeForHTTP
	"whether a character is 'safe', or needs to be escaped when used, eg, in a URL"
	^self isAlphaNumeric or: [ '.~-_' includes: self ]