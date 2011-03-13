onModificationOf: behaviors withTargets: targetBehaviors 
	| i |
	i := self new.
	i
		targetBehaviors: targetBehaviors;
		modifiedBehaviors: behaviors;
		decideParameters.
	^i