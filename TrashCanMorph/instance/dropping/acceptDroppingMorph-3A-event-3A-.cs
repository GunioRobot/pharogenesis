acceptDroppingMorph: aMorph event: evt

	| palette |
	self world soundsEnabled ifTrue: [self class playDeleteSound].
	evt hand endDisplaySuppression.
	self state: #off.
	aMorph delete.
	palette _ self world findA: EToyPalette.
	palette ifNotNil: [palette addToTrash: aMorph].
