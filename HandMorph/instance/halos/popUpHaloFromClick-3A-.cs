popUpHaloFromClick: evt
	"Pop up a halo on a suitable morph below the hand.
	If there are multiple possible targets, and one of them already has a halo, then
	choose the next inner target.  That is, unless we are already at the bottom, in which case
	go topmost again."

	| oldTargets targets anIndex |
	oldTargets _ OrderedCollection new.
	self world haloMorphs do:
		[:h | oldTargets addLast: h target. h delete].

	targetOffset _ self position.
	(argument _ self argumentOrNil) ifNil: [^ owner "the world" addHalo: evt].
	argument submorphCount = 0 ifTrue: [^ argument wantsHaloFromClick ifTrue: [argument addHalo: evt "sole target"]].

	"Multiple possible targets, choose the outermost suitable one first, but if one already
		has a halo, then choose the next farther in."
	targets _ argument unlockedMorphsAt: targetOffset.
	targets _ targets reversed select: [:aMorph | aMorph wantsHaloFromClick].

	targets size = 0 ifTrue: [^ argument wantsHaloFromClick
			ifTrue: [argument addHalo: evt "sole target"]
			ifFalse: ["no halo recipient"]].
	targets size = 1 ifTrue: [^ targets first addHalo: evt "sole target"].
	anIndex _ targets findFirst: [:t | oldTargets includes: t].
	anIndex = 0 ifTrue:
		[^ self popUpNewHaloFromClick: evt targets: targets].

	^ (targets atWrap: anIndex + 1) addHalo: evt from: (targets at: anIndex) "next inner target"