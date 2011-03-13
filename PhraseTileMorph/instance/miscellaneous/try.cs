try
	"Evaluate the given phrase once"

	| aPlayer |
	(userScriptSelector notNil and: [userScriptSelector numArgs = 0])
		ifTrue:
			[aPlayer _ self objectViewed player.
			aPlayer triggerScript: userScriptSelector]
		ifFalse:
			[Compiler evaluate:
				self codeString
				for: self associatedPlayer
				logged: false]