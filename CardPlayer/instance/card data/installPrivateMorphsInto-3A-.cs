installPrivateMorphsInto: aBackground
	"The receiver is being installed as the current card in a given pasteup morph being used as a background.  Install the receiver's private morphs into that playfield"

	| prior originToUse |
	self flag: #deferred.  "not robust if the background is showing a list view"
	privateMorphs ifNotNil: [privateMorphs do:
		[:aMorph |
			originToUse _ aBackground topLeft.
			prior _ aMorph valueOfProperty: #priorMorph ifAbsent: [nil].
			aMorph position: (aMorph position + originToUse).
			(prior notNil and: [aBackground submorphs includes: prior])
				ifTrue:
					[aBackground addMorph: aMorph after: prior]
				ifFalse:
					[aBackground addMorphFront: aMorph].
		aMorph removeProperty: #priorMorph]]