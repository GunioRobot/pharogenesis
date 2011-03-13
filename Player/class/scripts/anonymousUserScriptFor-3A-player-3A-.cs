anonymousUserScriptFor: aSelector player: aPlayer
	|  entry |
	scripts ifNil: [scripts _ IdentityDictionary new].
	self flag: #deferred.  "That anonymous script will of course contain refs to aPlayer who may well not be the class's prototype.  So if it is then saved, there's a problem"
	entry _ UserScript new initializeAnonymousScriptFor: aPlayer.
	scripts at: aSelector put: entry.
	^ entry