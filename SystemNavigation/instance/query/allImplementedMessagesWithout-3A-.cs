allImplementedMessagesWithout: classesAndMessagesPair 
	"Answer a Set of all the messages that are implemented in the system,  
	computed in the absence of the supplied classes and messages. Note this  
	reports messages that are in the absent selectors set."
	| messages absentClasses |
	messages _ IdentitySet new: CompiledMethod instanceCount.
	absentClasses _ classesAndMessagesPair first.
	self flag: #shouldBeRewrittenUsingSmalltalkAllClassesDo:. "sd 29/04/03" 
	Cursor execute
		showWhile: [Smalltalk classNames
				do: [:cName | ((absentClasses includes: cName)
						ifTrue: [{}]
						ifFalse: [{Smalltalk at: cName. (Smalltalk at: cName) class}])
						do: [:cl | messages addAll: cl selectors]]].
	^ messages