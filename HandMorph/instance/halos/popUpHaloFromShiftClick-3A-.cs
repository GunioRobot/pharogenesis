popUpHaloFromShiftClick: evt
	| oldTargets targets anIndex |
	"Given that the shift key is down, pop up a halo on an appropriate morph.  Go to the deepest morph (locked or not), unless there is an existing halo, in which case go out one level"
	oldTargets _ OrderedCollection new.
	self world haloMorphs do:
		[:h | oldTargets addLast: h innerTarget. h delete].

	targetOffset _ self position.
	(argument _ self argumentOrNil) ifNil: [^ owner "the world" addHalo: evt].
	argument submorphCount = 0 ifTrue: [^ argument addHalo: evt "sole target"].

	"Multiple possible targets, choose the deepest first, but if one already has a halo, then choose the next farther out.   Ignore renderers in the list"
	targets _ (argument morphsAt: targetOffset) reject: [:m | m isRenderer].

	targets size = 0 ifTrue: [^ argument addHalo: evt "sole target"].
	targets size = 1 ifTrue: [^ targets first addHalo: evt "sole target"].
	anIndex _ targets findFirst: [:t | oldTargets includes: t].
	anIndex = 0 ifTrue: [^ targets first addHalo: evt "deepest target"].
	^ (targets atWrap: anIndex + 1) addHalo: evt from: (targets at: anIndex) "next outer target"
