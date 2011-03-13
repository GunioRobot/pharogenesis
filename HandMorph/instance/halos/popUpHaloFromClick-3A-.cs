popUpHaloFromClick: evt
	"Pop up a halo on the deepest unlocked morph below the hand.
	However, if there are multiple possible targets, and one of them
	already has a halo, then choose the next outer target.  That is,
	unless we are already at the top, in which case go deepest again."
	| oldTargets targets i |
	oldTargets _ OrderedCollection new.
	self world haloMorphs do:
		[:h | oldTargets addLast: h target. h delete].

	targetOffset _ self position.
	(argument _ self argumentOrNil) ifNil: [^ owner "the world" addHalo].
	argument submorphCount = 0 ifTrue: [^ argument addHalo "sole target"].

	"Multiple possible targets, choose the deepest first, but
	if one already has a halo, then choose the next farther out."
	targets _ argument unlockedMorphsAt: targetOffset.
	targets size = 0 ifTrue: [^ argument addHalo "sole target"].
	targets size = 1 ifTrue: [^ targets first addHalo "sole target"].
	i _ targets findFirst: [:t | oldTargets includes: t].
	i = 0 ifTrue: [^ targets first addHalo "deepest target"].
	i < targets size ifTrue: [^ (targets at: i+1) addHalo "next outer
target"].
	^ targets first addHalo "All the way our already; back to deepest"