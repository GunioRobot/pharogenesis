emptyAnonymousScriptorFrom: aPlaceHoldingMorph
	| aScriptor |
	aScriptor _  (aPlaceHoldingMorph valueOfProperty: #player) anonymousScriptEditorFor: nil.
	aScriptor position: (self primaryHand position - (10 @ 10)).
	^ aScriptor