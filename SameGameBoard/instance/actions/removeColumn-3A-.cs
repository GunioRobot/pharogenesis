removeColumn: column

	| sourceTile |
	column+1 to: columns-1 do:
		[:c |
		0 to: rows-1 do:
			[:r |
			sourceTile _ self tileAt: c@r.
			(self tileAt: c-1@r)
				color: sourceTile color;
				disabled: sourceTile disabled]].
	0 to: rows-1 do:
		[:r | (self tileAt: columns-1@r) disabled: true]