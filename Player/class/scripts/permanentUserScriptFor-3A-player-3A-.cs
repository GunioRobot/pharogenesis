permanentUserScriptFor: aSelector player: aPlayer
	"Create and answer a suitable script  object for the given player (who will be an instance of the receiver) and selector.  Save that script-interface object in my (i.e. the class's) directory of scripts"

	|  entry |
	scripts ifNil: [scripts _ IdentityDictionary new].
	entry _ self nascentUserScriptInstance playerClass: aPlayer class selector: aSelector.
	scripts at: aSelector put: entry.
	^ entry