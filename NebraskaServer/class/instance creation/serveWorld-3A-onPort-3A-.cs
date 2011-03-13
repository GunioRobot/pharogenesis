serveWorld: aWorld onPort: aPortNumber

	| server |

	Utilities authorName.	"since we will need it later"

	server _ self newForWorld: aWorld.
	server startListeningOnPort: aPortNumber.
	^server
	"server acceptNullConnection"		"server acceptPhonyConnection."
