definition: theWord
	"look this word up in the basic way.  Return nil if there is trouble accessing the web site."
	| doc |

	word _ theWord.
	doc _ HTTPSocket 
		httpGetDocument: 'http://www.priberam.pt/scripts/dlpouniv.dll' 
		args: 'search_value=', (self class decodeAccents: word).
	replyHTML _ (doc isKindOf: MIMEDocument)
		ifTrue: [doc content]
		ifFalse: [nil].
	"self parseReply."

	^ replyHTML