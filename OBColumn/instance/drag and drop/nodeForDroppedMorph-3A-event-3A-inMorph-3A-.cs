nodeForDroppedMorph: transferMorph event: evt inMorph: pluggableListMorph
	| index item |
	index _ pluggableListMorph rowAtLocation: evt position.
	index = 0 ifTrue: [^ nil].
	item _ pluggableListMorph listMorph item: index.
	^ self nodeForItem: item inMorph: pluggableListMorph