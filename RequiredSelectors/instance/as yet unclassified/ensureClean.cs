ensureClean
	| rscc |
	dirty 
		ifTrue: 
			[rscc := RequiredSelectorsChangesCalculator 
						onModificationOf: self dirtyClasses
						withTargets: self classesOfInterest.
			rscc doWork.
			dirtyClasses := nil].
	dirty := false