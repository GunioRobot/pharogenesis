wantsDroppedMorph: aMorph event: evt
	"Answer whether the receiver would like to accept the given morph.  For a Parts bin, we accept just about anything except something that just originated from ourselves"

	(aMorph hasProperty: #beFullyVisibleAfterDrop) ifTrue:
		["Sign that this was launched from a parts bun, probably indeed this very parts bin"
		^ false].

	^ super wantsDroppedMorph: aMorph event: evt