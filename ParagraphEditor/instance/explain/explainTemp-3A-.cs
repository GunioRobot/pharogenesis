explainTemp: string 
	"Is string the name of a temporary variable (or block argument variable)?"

	| selectedClass tempNames i reply methodNode method msg |
	(model respondsTo: #selectedMessageName) ifFalse: [^ nil].
	(msg _ model selectedMessageName) ifNil: [^nil].	"not in a message"
	selectedClass _ model selectedClassOrMetaClass.
	tempNames _ selectedClass parserClass new 
			parseArgsAndTemps: model selectedMessage notifying: nil.
	method _ selectedClass compiledMethodAt: msg.
	(i _ tempNames findFirst: [:each | each = string]) = 0 ifTrue: [
		(method numTemps > tempNames size)
			ifTrue: 
				["It must be an undeclared block argument temporary"
				methodNode _ selectedClass compilerClass new
							parse: model selectedMessage
							in: selectedClass
							notifying: nil.
				tempNames _ methodNode tempNames]
			ifFalse: [^nil]].
	(i _ tempNames findFirst: [:each | each = string]) > 0 ifTrue: [i > method numArgs
			ifTrue: [reply _ '"is a temporary variable in this method"']
			ifFalse: [reply _ '"is an argument to this method"']].
	^reply