testCompileSuperBranch
	"The compiler accepts this code 
		condition ifTrue: [super] ifFalse: [self]
	but compiles it as 
		condition ifTrue: [super] ifFalse: [self].
	(Use the show decompiled button).  So the SendsInfo interpreter, interpretting 
	the bad code, comes up with the wrong answer."

	self should: [(state isNil
		ifTrue: [super]
		ifFalse: [self]) tell] raise: MessageNotUnderstood description: 'Compiler treats super as self'
	