serveWorld: aWorld onPort: aPortNumber

	| server |
	server := NebraskaServer serveWorld: aWorld onPort: aPortNumber.
	(self new) openInWorld: aWorld.

	"server acceptNullConnection"		"server acceptPhonyConnection."
