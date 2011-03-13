addExtrasFor: anEToyHolder inWorld: aWorld
	| nrBot fred fredMorph |
	nrBot _ aWorld height - 30.
	fred _ anEToyHolder standardPlayerInWorld: aWorld.
	aWorld addMorphBack: (fredMorph _ fred costume).
	fredMorph position: (330 @ nrBot)