costumesDo: aBlock
	"Evaluate aBlock against every real (not flex) costume known to the receiver)"
	aBlock value: costume renderedMorph.
	costumes ifNotNil:
		[(costumes copyWithout: costume) do:
			[:aCostume | aBlock value: aCostume]]