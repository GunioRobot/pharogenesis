logChange: aStringOrText
	"Write the argument, aString, onto the changes file."
	| aFileStream aString |
	(SourceFiles isNil or: [(SourceFiles at: 2) == nil]) ifTrue: [^self].
	(aStringOrText isMemberOf: Text)
		ifTrue: [aString _ aStringOrText string]
		ifFalse: [aString _ aStringOrText].
	(aString isMemberOf: String)
		ifFalse: [self error: 'cant log this change'].
	(aString findFirst: [:char | char isSeparator not]) = 0
		ifTrue: [^self].  "null doits confuse replay"
	(SourceFiles at: 2) setToEnd;
			cr; cr; nextChunkPut: aString.
	self forceChangesToDisk.