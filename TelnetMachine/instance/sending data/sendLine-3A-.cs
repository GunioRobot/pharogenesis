sendLine: aString
	"send a line, along with a newline"
	self processTyping: aString, String crlf.
	^true