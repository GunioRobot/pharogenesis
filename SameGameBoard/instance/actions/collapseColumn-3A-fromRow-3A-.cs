collapseColumn: col fromRow: row

	| targetTile sourceTile |
	(targetTile _ self tileAt: col@row) disabled ifTrue:
		[row - 1 to: 0 by: -1 do:
			[:r |
			(sourceTile _ self tileAt: col@r) disabled ifFalse:
				[targetTile color: sourceTile color.
				targetTile disabled: false.
				sourceTile disabled: true.
				^ true]]].
	^ false
