unusedTempNames 
	| unused |
	unused _ OrderedCollection new.
	scopeTable associationsDo:
		[:assn | (assn value isUnusedTemp)
			ifTrue: [unused add: assn value key]].
	^ unused