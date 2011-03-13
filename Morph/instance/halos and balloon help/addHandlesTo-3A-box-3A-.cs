addHandlesTo: aHaloMorph box: box
	"Add halo handles to the halo.  Apply the halo filter if appropriate"

	| wantsIt aSelector |
	aHaloMorph haloBox: box.
	Preferences haloSpecifications  do:
		[:aSpec | 
			aSelector :=  aSpec addHandleSelector.
			wantsIt := Preferences selectiveHalos
				ifTrue:
					[self wantsHaloHandleWithSelector: aSelector inHalo: aHaloMorph]
				ifFalse:
					[true].
			wantsIt ifTrue:
				[(#(addDupHandle:) includes: aSelector) ifTrue:
					[wantsIt := self preferredDuplicationHandleSelector = aSelector].
			wantsIt ifTrue:
				[aHaloMorph perform: aSelector with: aSpec]]].

	aHaloMorph innerTarget addOptionalHandlesTo: aHaloMorph box: box