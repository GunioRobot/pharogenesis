copyStateFrom: anotherClass
	| dupScript |
	scripts _ IdentityDictionary new.
	anotherClass userScriptsDo:
		[:aScript | 
			aScript isAnonymous ifFalse:
				[dupScript _ aScript shallowCopy.
				dupScript initializeForPlayer: self flagshipInstance afterShallowCopyFrom: aScript.
				scripts at: aScript selector put: dupScript]].
	slotInfo _ anotherClass slotInfo deepCopy.
	self copyAddedStateFrom: anotherClass.  "The player-ref jump table"