openModelIntoAlice: fullName
	"If a Wonderland exists, load this model into it as an actor.  
	If it doesn't, make one first"

	| alice |
	Smalltalk isMorphic 
		ifFalse: [^self error: 'Only works in Morphic -  sorry!'].
	alice _ World submorphs 
				detect: [:m | m isKindOf: WonderlandEditor] 
				ifNone: [nil].
	alice isNil 
		ifTrue: [alice := Wonderland new] 
		ifFalse: [alice := alice getWonderland].
	alice makeActorFrom: fullName.

	