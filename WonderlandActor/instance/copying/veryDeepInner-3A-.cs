veryDeepInner: deepCopier
	"Special code that handles user-added instance variables of a uniClass.
	Copy all of my instance variables.  Some need to be not copied at all, but shared.  This is special code for the dictionary.  See DeepCopier."
	| instVar weak subAss |

	super veryDeepInner: deepCopier.
	"my own instance variables are completely normal"
	myName _ myName veryDeepCopyWith: deepCopier.
	myWonderland _ myWonderland.		"don't make a new one"
	myMesh _ myMesh veryDeepCopyWith: deepCopier.
	myTexture _ myTexture veryDeepCopyWith: deepCopier.
	myMaterial _ myMaterial veryDeepCopyWith: deepCopier.
	myColor _ myColor veryDeepCopyWith: deepCopier.
	scaleMatrix _ scaleMatrix veryDeepCopyWith: deepCopier.
	hidden _ hidden veryDeepCopyWith: deepCopier.
	firstClass _ firstClass veryDeepCopyWith: deepCopier.
	myReactions _ myReactions veryDeepCopyWith: deepCopier.
	myProperties _ myProperties veryDeepCopyWith: deepCopier.	"may copy too deeply"

	WonderlandActor instSize + 1 to: self class instSize do: [:index |
		instVar _ self instVarAt: index.
		weak _ instVar isMorph | instVar isPlayerLike. 
		(subAss _ deepCopier references associationAt: instVar ifAbsent: [nil])
				"use association, not value, so nil is an exceptional value"
			ifNil: [weak ifFalse: [
					self instVarAt: index put: (instVar veryDeepCopyWith: deepCopier)]]
			ifNotNil: [self instVarAt: index put: subAss value].
		].
