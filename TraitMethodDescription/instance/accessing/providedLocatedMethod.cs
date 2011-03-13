providedLocatedMethod
	| locatedMethod |
	locatedMethod _ nil.
	self locatedMethods do: [:each |
		each method isProvided ifTrue: [
			locatedMethod isNil ifFalse: [^nil].
			locatedMethod _ each]].
	^locatedMethod