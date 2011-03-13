try
	| aPlayer |
	userScriptSelector == nil
		ifFalse:
			[aPlayer _ self objectViewed costumee.
			aPlayer perform: userScriptSelector]
		ifTrue:
			[Compiler evaluate:
				self codeString
				for: self player
				logged: false].
	(Delay forMilliseconds: 200) wait