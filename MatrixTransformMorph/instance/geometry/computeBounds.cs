computeBounds
	| subBounds |
	(submorphs isNil or:[submorphs isEmpty]) ifTrue:[^self].
	bounds _ nil.
	submorphs do:[:m|
		subBounds _ self transform localBoundsToGlobal: m bounds.
		bounds 
			ifNil:[bounds _ subBounds]
			ifNotNil:[bounds _ bounds quickMerge: subBounds].
	].
	bounds ifNil:[bounds _ 0@0 corner: 20@20].
	fullBounds _ bounds.