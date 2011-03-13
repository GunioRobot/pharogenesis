rootTile
	^ self orOwnerSuchThat:
		[:m | m owner == nil or: [m owner isSyntaxMorph not]]