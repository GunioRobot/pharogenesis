allMorphsDo: aBlock
	"Enumerate all morphs in the world, including those held in hands."

	super allMorphsDo: aBlock.
	hands reverseDo: [:h | h allMorphsDo: aBlock].
