hasCostumeThatIsAWorld
	(costume renderedMorph isWorldMorph) ifTrue: [^ true].
	costumes ifNotNil:
		[costumes do:
			[:aCostume | (aCostume isWorldMorph) ifTrue: [^ true]]].
	^ false