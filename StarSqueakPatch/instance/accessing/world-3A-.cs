world: aStarSqueakMorph
	"Set the world for this patch. Also record the world's width and height."

	| dims |
	world _ aStarSqueakMorph.
	dims _ world dimensions.
	worldWidth _ dims x.
	worldHeight _ dims y.
