obsoleteBehaviors
	"Smalltalk obsoleteBehaviors inspect"
	"Find all obsolete behaviors including meta classes"
	| obs |
	self deprecated: 'Use SmalltalkNavigation default obsoleteBehaviors'.
	obs := OrderedCollection new.
	self garbageCollect.
	self systemNavigation
		allObjectsDo: [:cl | (cl isBehavior
					and: [cl isObsolete])
				ifTrue: [obs add: cl]].
	^ obs asArray