tilesRemaining

	^ (submorphs reject: [:m | m disabled]) size
