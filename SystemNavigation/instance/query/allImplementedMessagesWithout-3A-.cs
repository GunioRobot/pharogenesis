allImplementedMessagesWithout: classesAndMessagesPair 
	"Answer a Set of all the messages that are implemented in the system,  
	computed in the absence of the supplied classes and messages. Note this  
	reports messages that are in the absent selectors set."
	| messages absentClasses |
	messages := IdentitySet new: CompiledMethod instanceCount.
	absentClasses := classesAndMessagesPair first.
	self flag: #shouldBeRewrittenUsingSmalltalkAllClassesDo:. "sd 29/04/03" 
	Cursor execute showWhile: [
		Smalltalk classNames , Smalltalk traitNames
			do: [:name | ((absentClasses includes: name)
				ifTrue: [{}]
				ifFalse: [{Smalltalk at: name. (Smalltalk at: name) classSide}])
					do: [:each | messages addAll: each selectors]]].
	^ messages