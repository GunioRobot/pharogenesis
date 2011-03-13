decideParameters
	"decide whos who"

	targetClasses := IdentitySet new.
	targetTraits := IdentitySet new.
	self targetBehaviors 
		do: [:b | b isTrait ifTrue: [targetTraits add: b] ifFalse: [targetClasses add: b]].
	self findAffectedTraitsFrom: targetTraits.
	self findRootsAndRoutes.
	self findOriginalSins