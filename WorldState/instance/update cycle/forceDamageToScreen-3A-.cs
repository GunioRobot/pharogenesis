forceDamageToScreen: allDamage

	"here for the convenience of NebraskaWorldState"
	allDamage do: [:r | Display forceToScreen: r].
	self remoteCanvasesDo: [ :each | 
		allDamage do: [:r | each forceToScreen: r].
		each displayIsFullyUpdated.
	].