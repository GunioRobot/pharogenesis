connection: connection requestedForUsername: username  andPassword: password  toRemovePackageNamed: packageName withVersion: version
	| packagesToRemove response |
	response _ policy packageNamed: packageName withVersion: version mayBeRemovedBy: username withPassword: password.
	
	response allowed ifFalse: [
		^self 
			sendError: 'removing package ', packageName, ' failed (', response reason, ')' 
			onConnection: connection].
		
	packagesToRemove := universe packages select: [ :p | p name = packageName and: [ p version = version ] ].
	packagesToRemove do: [ :p |
		universe removePackage: p ].
	
	self sendMessage: (UMPackageRemoved packageName: packageName version: version) onConnection: connection.