unusedTempNames 
	| unused name |
	unused _ OrderedCollection new.
	scopeTable associationsDo:
		[:assn | (assn value isUnusedTemp)
			ifTrue: [name _ assn value key.
					name ~= 'homeContext' ifTrue: [unused add: name]]].
	^ unused