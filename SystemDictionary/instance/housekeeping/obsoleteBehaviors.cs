obsoleteBehaviors   "Smalltalk obsoleteBehaviors inspect"
	"Find all obsolete behaviors including meta classes"
	| obs |
	obs _ OrderedCollection new.
	Smalltalk garbageCollect.
	self allObjectsDo:[:cl|
		(cl isBehavior and:[cl isObsolete]) ifTrue:[obs add: cl]].
	^ obs asArray