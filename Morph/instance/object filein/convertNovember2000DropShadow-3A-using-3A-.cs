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
			rend privateOwner: owner.
			extension ifNotNil: [
				extension externalName ifNotNil: [rend setNameTo: self extension externalName]].
			^rend].
	(rend := Morph new) color: Color transparent.
	^ rend