calculateForClass: aClass 
	| rscc |
	self clearOut: aClass.
	rscc := RequiredSelectorsChangesCalculator onModificationOf: { aClass }
				withTargets: { aClass }.
	rscc doWork