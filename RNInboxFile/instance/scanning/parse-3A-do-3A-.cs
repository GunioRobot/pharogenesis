parse: aStream do: aBlock
	"Parse the given stream into newsgroup articles, invoking the given block once for each article in the stream. The stream is divided into articles by delimiters that includes the newsgroup name. Ignore text before the first article delimiter."

	| done line groupName |
	currentNewsgroup _ nil.  "have not found start of article"
	msgBuffer _ WriteStream on: (String new: 5000).
	done _ false.
	[done] whileFalse:
		[(aStream atEnd) ifTrue:
			["end of stream"
			 self endOfArticleDo: aBlock.
			 done _ true].
		 line _ MailDB readStringLineFrom: aStream.
		 groupName _ self startOfArticle: line.
		 (groupName notNil) ifTrue:
			[self endOfArticleDo: aBlock.
			 currentNewsgroup _ groupName.
			 line _ MailDB readStringLineFrom: aStream].
		 (currentNewsgroup notNil) ifTrue: [self appendLine: line]].