popUpNewHaloFromClick: evt targets: targets
	| outer possible haloRecipient |
	"Pop up a halo for the most opportune morph, given that this is not a progressive halo transfer.  evt is the precipitating mouse event, and targets is the list of potential targets under the mouse"
	possible _ targets detect: [:aMorph |
			 (aMorph isKindOf: PasteUpMorph) not and: [(aMorph isKindOf: BookMorph) not]]
		ifNone: [targets last].
	
	outer _ possible owner ifNil: [targets first].
	haloRecipient _ targets reversed detect:
		[:aMorph | aMorph == outer or: [aMorph seeksOutHalo and: [outer defersHaloOnClickTo: aMorph]]] ifNone: [outer].
	haloRecipient _ targets detect:
			[:aMorph | (aMorph defersHaloOnClickTo: haloRecipient) not]
		ifNone: [haloRecipient].
	haloRecipient addHalo: evt
