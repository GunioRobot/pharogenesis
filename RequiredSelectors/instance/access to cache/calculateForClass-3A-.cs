calculateForClass: aClass 
	| rscc |
	rscc := RequiredSelectorsChangesCalculator onModificationOf: { aClass }
				withTargets: { aClass }.
	rscc doWork