usablePhraseSpecsIn: aListOfTuples
	"Filter the list given by aListOfTuples, to remove items inappropriate to the receiver"

	self hasCostumeThatIsAWorld ifTrue:
		[^ aListOfTuples select: [:tuple |
			#(beep doMenuItem color startScript: stopScript: pauseScript: liftAllPens lowerAllPens clearTurtleTrails initiatePainting cursor valueAtCursor mouseX mouseY roundUpStrays unhideHiddenObjects) includes: tuple second]].

	self hasAnyBorderedCostumes ifTrue: [^ aListOfTuples].

	^ self hasOnlySketchCostumes
		ifTrue:
			[aListOfTuples select: [:tuple | (#(color borderColor borderWidth) includes: tuple second) not]]
		ifFalse:
			[aListOfTuples select: [:tuple | (#(borderColor borderWidth) includes: tuple second) not]]
