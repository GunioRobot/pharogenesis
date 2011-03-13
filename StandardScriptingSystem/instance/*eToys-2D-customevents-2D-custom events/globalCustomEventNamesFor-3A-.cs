globalCustomEventNamesFor: aPlayer
	| morph names |
	morph := aPlayer costume renderedMorph.
	names := SortedCollection new.
	self customEventsRegistry keysAndValuesDo: [ :k :v |
		(v anySatisfy: [ :array | morph isKindOf: array second ])
			ifTrue: [ names add: k ]].
	^names asArray