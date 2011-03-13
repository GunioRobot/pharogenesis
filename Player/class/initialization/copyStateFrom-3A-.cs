copyStateFrom: anotherClass
	| dupScript |
	self copyAddedStateFrom: anotherClass.  "being the reference table stored in inst vars of the class"
	scripts _ IdentityDictionary new.
	anotherClass userScriptsDo:
		[:aScript | 
			aScript isAnonymous ifFalse:
				[dupScript _ aScript shallowCopy.
				dupScript initializeForPlayer: self flagshipInstance afterShallowCopyFrom: aScript.
				scripts at: aScript selector put: dupScript]].
	slotInfo _ anotherClass slotInfo deepCopy