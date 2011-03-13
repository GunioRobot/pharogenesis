renameScript: oldSelector
	"The user has asked to rename the script formerly known by oldSelector; obtain a new selector from the user, check it out, and if all is well, ascribe the new name as appropriate"

	| reply newSelector aUserScript |
	self flag: #deferred.  "Relax the below, yes?"
	aUserScript _ self class userScriptForPlayer: self selector: oldSelector.
	aUserScript isTextuallyCoded ifTrue:
		[self inform: 'Sorry, for now you can only rename tiled scripts'.
		^ self].

	reply _   FillInTheBlank request: 'Script Name' initialAnswer: oldSelector.
 	reply size == 0 ifTrue: [^ self].
	reply = oldSelector ifTrue:[^ self beep].

	newSelector _ ScriptingSystem acceptableScriptNameFrom: reply  forScriptCurrentlyNamed:  oldSelector asScriptNameIn: self world: costume world.
	(self currentWorld hasProperty: #universalTiles) 
		ifTrue:
			["allow colons"
			(reply copyWithout: $:) = newSelector 
				ifTrue: [newSelector _ reply asSymbol]
				ifFalse: [self inform: 'name will be modified']].	

	self renameScript: oldSelector newSelector: newSelector
