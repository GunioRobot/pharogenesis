endOfArticleDo: aBlock
	"We've just hit the end of an article. Evaluate the given block on the article we've been accumulating in the buffer (if any) and reset the buffer for the next article."

	| msgText end |
	"get text and remove trailing separators (blanks, cr's, etc)"
	msgText _ msgBuffer contents.
	end _ msgText size.
	[(end > 0) and: [(msgText at: end) isSeparator]] whileTrue: [end _ end - 1].
	(end > 1) ifTrue:
		[aBlock value: currentNewsgroup value: (msgText copyFrom: 1 to: end)].
	msgBuffer reset.	"reset the buffer for the next message"