try
	| aPlayer |
	userScriptSelector == nil
		ifFalse:
			[aPlayer _ self objectViewed player.
			aPlayer perform: userScriptSelector]
		ifTrue:
			[Compiler evaluate:
				self codeString
				for: self associatedPlayer
				logged: false]