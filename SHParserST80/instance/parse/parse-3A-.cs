parse: isAMethod 
	"Parse the receiver's text. If isAMethod is true
    then treat text as a method, if false as an
    expression with no message pattern"

	self initializeInstanceVariables.
	sourcePosition := 1.
	arguments := Dictionary new.
	temporaries := Dictionary new.
	blockDepth := bracketDepth := 0.
	ranges isNil 
		ifTrue: [ranges := OrderedCollection new: 100]
		ifFalse: [ranges reset].
	errorBlock := [^false].
	self scanNext.
	isAMethod ifTrue: [self parseMessagePattern].
	self parseMethodTemporaries.
	self parsePrimitiveOrExternalCall.
	self parseStatementList.
	currentToken ifNotNil: [self error].
	^true