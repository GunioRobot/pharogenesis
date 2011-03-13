connection: connection requestedForUsername: username  andPassword: password  toAddPackage: package
	| response |
	response _ policy package: package mayBeAddedBy: username withPassword: password.
	
	response allowed
		ifFalse: [
			^self 
				sendError: 'adding package ', package name, ' failed (', response reason, ')'
				onConnection: connection].
		
	universe addPackage: package.


	self sendMessage: (UMPackageAdded package: package) onConnection: connection.