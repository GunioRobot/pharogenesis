parse: aStream do: aBlock
	"Parse the given stream into newsgroup articles, invoking the given block once for each article in the stream. The stream is divided into articles by two kinds of delimiters. The first kind indicates the start of a new newsgroup and includes the newsgroup name. The second kind indicates the start of a new article within a newsgroup."

	| done line nextLine |
	currentNewsgroup _ 'unknown newsgroup'.
	msgBuffer _ WriteStream on: (String new: 5000).
	done _ false.
	[done] whileFalse:
		[(aStream atEnd) ifTrue:
			["end of stream"
			 self endOfArticleDo: aBlock.
			 done _ true].
		 line _ MailDB readStringLineFrom: aStream.
		 (self allDashes: line) ifTrue:	"leading line of dashes"
			["could be a newsgroup header"
			 nextLine _ MailDB readStringLineFrom: aStream.
			 ((nextLine size >= 10) and:
			  [(nextLine copyFrom: 1 to: 10) = 'Newsgroup '])
				ifTrue:
					["yep, it is a newsgroup header"
					 self endOfArticleDo: aBlock.
					 self setNewsGroup: nextLine.
					 MailDB skipRestOfLine: aStream.	"skip trailing line of dashes"
					 MailDB skipRestOfLine: aStream.	"skip blank line"
					 MailDB skipRestOfLine: aStream.	"skip next article delimiter"
					 line _ MailDB readStringLineFrom: aStream]
				ifFalse:
					["nope, it's not a newsgroup header"
					 self appendLine: line.
					 line _ nextLine]].
		 (self startOfArticle: line) ifTrue:
			[self endOfArticleDo: aBlock.
			 line _ MailDB readStringLineFrom: aStream].
		 self appendLine: line].	"normal line: append it to the message buffer"