computeBounds
	| subBounds box |
	(submorphs isNil or:[submorphs isEmpty]) ifTrue:[^self].
	box _ nil.
	submorphs do:[:m|
		subBounds _ self transform localBoundsToGlobal: m bounds.
		box 
			ifNil:[box _ subBounds]
			ifNotNil:[box _ box quickMerge: subBounds].
	].
	box ifNil:[box _ 0@0 corner: 20@20].
	fullBounds _ bounds _ box