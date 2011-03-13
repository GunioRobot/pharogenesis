startUp
	World ifNotNil: [World install].
	"Author fullName: ''."
	^self startUpAfterLogin.