openPopConnectionTo: server  forUser: userName  password: password  loginMethod: loginMethod
	| client |
	Utilities
		informUser: 'connecting to ', server
			during: [
				client _ POP3Client openOnHostNamed: server.
				client loginUser: userName password: password loginMethod: loginMethod.
				client logProgressToTranscript].
	^client