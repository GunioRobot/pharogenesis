parseTTCHeaderFrom: fontData

	| pos nTables |
	nTables _ fontData longAt: 9 bigEndian: true.
	fonts _ Array new: nTables.
	pos _ 13.
	1 to: nTables do: [:i |
		fonts at: i put: (fontData longAt: pos bigEndian: true).
		pos _ pos + 4.
	].

	^ fonts
