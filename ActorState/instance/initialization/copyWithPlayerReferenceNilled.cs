copyWithPlayerReferenceNilled
	"Answer a copy of the receiver in which all the items referring to the corresponding Player object are nilled out, for the purpose of being set up with fresh values, after the copy, by the caller"

	| holdPlayer holdScriptDict copy copyScriptDict |
	holdPlayer _ owningPlayer.
	owningPlayer _ nil.
	holdScriptDict _ self instantiatedUserScriptsDictionary.
	instantiatedUserScriptsDictionary _ nil.
	copy _ self deepCopy.
	owningPlayer _ holdPlayer.
	instantiatedUserScriptsDictionary _ holdScriptDict.
	holdScriptDict ifNotNil:
		[copyScriptDict _ IdentityDictionary new.
		holdScriptDict associationsDo:
			[:assoc |
				copyScriptDict add: (assoc key -> (assoc value copyWithPlayerObliterated))].
		copy instantiatedUserScriptsDictionary: copyScriptDict].
	^ copy
