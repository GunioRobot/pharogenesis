logChange: aStringOrText 
	"Write the argument, aString, onto the changes file."
	
	self deprecated: 'Use SmalltalkImage current logChange:'.
	SmalltalkImage current logChange: aStringOrText.	
	
"	| aString changesFile |
	(SourceFiles isNil or: [(SourceFiles at: 2) == nil]) ifTrue: [^ self].
	self assureStartupStampLogged.

	aStringOrText isText
		ifTrue: [aString _ aStringOrText string]
		ifFalse: [aString _ aStringOrText].
	(aString isMemberOf: String)
		ifFalse: [self error: 'can''t log this change'].
	(aString findFirst: [:char | char isSeparator not]) = 0
		ifTrue: [^ self].
	(changesFile _ SourceFiles at: 2).
	changesFile isReadOnly ifTrue:[^self].
	changesFile setToEnd; cr; cr.
	changesFile nextChunkPut: aString.
	self forceChangesToDisk.
"