copyTwoLevel
	"one more level than a shallowCopy"

	| newObject class index |
	class _ self class.
	newObject _ self clone.
	newObject == self ifTrue: [^ self].
	class isVariable
		ifTrue: 
			[index _ self basicSize.
			[index > 0]
				whileTrue: 
					[newObject basicAt: index put: (self basicAt: index) shallowCopy.
					index _ index - 1]].
	index _ class instSize.
	[index > 0]
		whileTrue: 
			[newObject instVarAt: index put: (self instVarAt: index) shallowCopy.
			index _ index - 1].
	^newObject