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
			self hasExtension 
				ifTrue: 
					[""

					self extension actorState 
						ifNotNil: [rend actorState: self extension actorState].
					self extension externalName 
						ifNotNil: [rend setNameTo: self extension externalName].
					self extension player ifNotNil: 
							[""

							rend player: self extension player.
							self extension player rawCostume: rend]].
			^rend].
	(rend := Morph new) color: Color transparent.
	^rend