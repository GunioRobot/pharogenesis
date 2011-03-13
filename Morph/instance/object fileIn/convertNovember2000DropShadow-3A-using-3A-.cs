convertNovember2000DropShadow: varDict using: smartRefStrm
	| rend |
	"Work hard to eliminate the DropShadow.  Inst vars are already stored into."

	submorphs size > 0 ifTrue: [
		rend _ submorphs first renderedMorph.	"a text?"
		rend setProperty: #hasDropShadow toValue: true.
		rend setProperty: #shadowColor toValue: (varDict at: 'color').
		rend setProperty: #shadowOffset toValue: (varDict at: 'shadowOffset').
		"ds owner ifNotNil: [ds owner addAllMorphs: ds submorphs].   ^rend does this"
		rend privateOwner: owner.
		extension ifNotNil: [
			extension actorState ifNotNil: [
				rend actorState: extension actorState].
			extension externalName ifNotNil: [
				rend setNameTo: extension externalName].
			extension player ifNotNil: [
				rend player: extension player.
				extension player rawCostume: rend]].
		^ rend].
	(rend _ Morph new) color: Color transparent.
	^ rend
