explainTemp: string 
	"Is string the name of a temporary variable (or block argument variable)?"

	| selectedClass tempNames i reply methodNode method |
	model messageListIndex = 0 ifTrue: [^nil].	"no message is selected"
	selectedClass _ model selectedClassOrMetaClass.
	tempNames _ selectedClass parserClass new parseArgsAndTemps: model selectedMessage notifying: nil.
	method _ selectedClass compiledMethodAt: model selectedMessageName.
	(i _ tempNames findFirst: [:each | each = string]) = 0 ifTrue: [
		(method numTemps > tempNames size)
			ifTrue: 
				["It must be an undeclared block argument temporary"
				methodNode _ selectedClass compilerClass new
							parse: model selectedMessage
							in: model selectedClassOrMetaClass
							notifying: nil.
				tempNames _ methodNode tempNames]
			ifFalse: [^nil]].
	(i _ tempNames findFirst: [:each | each = string]) > 0 ifTrue: [i > method numArgs
			ifTrue: [reply _ '"is a temporary variable in this method"']
			ifFalse: [reply _ '"is an argument to this method"']].
	^reply