convertNovember2000DropShadow: varDict using: smartRefStrm 
	"Work hard to eliminate the DropShadow. Inst vars are already  
	stored into."

	| rend |
	submorphs notEmpty 
		ifTrue: 
			[rend := submorphs first renderedMorph.
			"a text?"
			rend setProperty: #hasDropShadow toValue: true.
			rend setProperty: #shadowColor toValue: (varDict at: 'color').
			rend setProperty: #shadowOffset toValue: (varDict at: 'shadowOffset').
			"ds owner ifNotNil: [ds owner addAllMorphs: ds  
			submorphs]. ^rend does this"
			rend privateOwner: owner.
			extension ifNotNil: [
				extension actorState  ifNotNil: [rend actorState: self extension actorState].
				extension externalName ifNotNil: [rend setNameTo: self extension externalName].
				extension player ifNotNil: [
							rend player: extension player.
							extension player rawCostume: rend]].
			^rend].
	(rend := Morph new) color: Color transparent.
	^rend