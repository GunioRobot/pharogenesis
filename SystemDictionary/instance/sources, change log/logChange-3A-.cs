logChange: aStringOrText
	"Write the argument, aString, onto the changes file."
	| aString |
	(SourceFiles isNil or: [(SourceFiles at: 2) == nil]) ifTrue: [^self].
	aStringOrText isText
		ifTrue: [aString _ aStringOrText string]
		ifFalse: [aString _ aStringOrText].
	(aString isMemberOf: String)
		ifFalse: [self error: 'cant log this change'].
	(aString findFirst: [:char | char isSeparator not]) = 0
		ifTrue: [^self].  "null doits confuse replay"
	(SourceFiles at: 2) setToEnd;
			cr; cr; nextChunkPut: aString.
		"If want style changes in DoIt, use nextChunkPutWithStyle:, and allow Texts to get here"
	self forceChangesToDisk.