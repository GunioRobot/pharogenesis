definition: theWord
	"look this word up in the basic way.  Return nil if there is trouble accessing the web site."
	| doc |
	word _ theWord.
	Cursor wait showWhile: [
		doc _ HTTPSocket 
			httpGetDocument: 'http://www.cogsci.princeton.edu/cgi-bin/webwn/' 
			args: 'stage=1&word=', word].
	replyHTML _ (doc isKindOf: MIMEDocument)
		ifTrue:
			[doc content]
		ifFalse:
			[nil].
	"self parseReply."

	^ replyHTML