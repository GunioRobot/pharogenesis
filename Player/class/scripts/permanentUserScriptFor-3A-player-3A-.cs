permanentUserScriptFor: aSelector player: aPlayer
	"Create and answer a UserScript object for the given player (an instance of the receiver) and selector.  Save that UniclassScript in my (i.e. the class's) directory of scripts"

	|  entry |
	scripts ifNil: [scripts _ IdentityDictionary new].
	entry _ UniclassScript new playerClass: aPlayer class selector: aSelector.
	scripts at: aSelector put: entry.
	^ entry