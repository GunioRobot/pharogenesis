user: userId
	"Return the requesting user."
	^users at: userId ifAbsent: [ self error: (PWS unauthorizedFor: realm) ]