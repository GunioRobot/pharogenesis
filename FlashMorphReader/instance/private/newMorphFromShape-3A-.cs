newMorphFromShape: objectIndex
	"Return a new character morph from the given object index.
	If the character morph at objectIndex is already used, then create and return a full copy of it"
	| prototype |

	prototype _ self oldMorphFromShape: objectIndex.
	prototype isNil ifTrue:[^nil].
	^(prototype owner notNil) 
		ifTrue:[prototype veryDeepCopy]
		ifFalse:[prototype].