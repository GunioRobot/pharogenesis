invokeMetaMenuFor: aMorph
	| menu |
	menu _ self buildMorphMenuFor: aMorph.
	menu addTitle: aMorph externalName.
	self invokeMenu: menu event: lastEvent
