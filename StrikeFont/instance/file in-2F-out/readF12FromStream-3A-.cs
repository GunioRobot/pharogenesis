readF12FromStream: aStream

	| box blt |
	minAscii _ 0.
	maxAscii _ 94*94.
	ascent _ 12.
	descent _ 0.
	pointSize _ 12.
	superscript _ 0.
	subscript _ 0.
	emphasis _ 0.
	maxWidth _ 12.
	
	box _ Form extent: 12@12.
	glyphs  _ Form extent: (94*94*12)@12.
	blt _ BitBlt toForm: glyphs. 
	xTable _ XTableForFixedFont new.
	xTable maxAscii: maxAscii + 3.
	xTable width: 12.
	1 to: 256 do:  [:index | 
		1 to: 12 do: [:i |
			aStream next.
		].
	].
	(minAscii + 1 to: 94*94) do:  [:index | 
		self readCharacter: (box bits) from: aStream.
		blt copy: ((12*(index-1))@0 extent: 12@12) from: 0@0 in: box.
	].
