activeTab: aTabMorph
	self activeTab ifNotNil: [self activeTab toggle].
	activeTab _ aTabMorph.
	self activeTab toggle.
	aTabMorph delete.
	self addMorphFront: aTabMorph.
	self performActiveTabAction.
	self changed.
