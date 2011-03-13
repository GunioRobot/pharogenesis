readF12FromStream: aStream 
	| box blt |
	minAscii := 0.
	maxAscii := 94 * 94.
	ascent := 12.
	descent := 0.
	pointSize := 12.
	superscript := 0.
	subscript := 0.
	emphasis := 0.
	maxWidth := 12.
	box := Form extent: 12 @ 12.
	glyphs := Form extent: (94 * 94 * 12) @ 12.
	blt := BitBlt toForm: glyphs.
	xTable := XTableForFixedFont new.
	xTable maxAscii: maxAscii + 3.
	xTable width: 12.
	1 
		to: 256
		do: 
			[ :index | 
			1 
				to: 12
				do: [ :i | aStream next ] ].
	(minAscii + 1 to: 94 * 94) do: 
		[ :index | 
		self 
			readCharacter: box bits
			from: aStream.
		blt 
			copy: ((12 * (index - 1)) @ 0 extent: 12 @ 12)
			from: 0 @ 0
			in: box ]