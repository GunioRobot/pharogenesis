world: aStarSqueakMorph
	"Set the world for this patch. Also record the world's width and height."

	| dims |
	world := aStarSqueakMorph.
	dims := world dimensions.
	worldWidth := dims x.
	worldHeight := dims y.
