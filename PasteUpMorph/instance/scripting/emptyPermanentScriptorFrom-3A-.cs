emptyPermanentScriptorFrom: aPlaceHoldingMorph
	| aScriptor aPlayer |
	aPlayer _ aPlaceHoldingMorph valueOfProperty: #player.
	aPlayer assureUniClass.
	aScriptor _  aPlayer permanentScriptEditorFor: nil.
	aScriptor position: (self primaryHand position - (10 @ 10)).
	aPlayer updateAllViewersAndForceToShow: 'scripts'.
	^ aScriptor