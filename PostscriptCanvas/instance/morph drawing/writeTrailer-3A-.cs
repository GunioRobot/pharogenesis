writeTrailer: pages 
	target
		print: '%%Trailer';
		cr.
	usedFonts isEmpty 
		ifFalse: 
			[target print: '%%DocumentFonts:'.
			usedFonts values asSet do: 
					[:f | 
					target
						space;
						print: f].
			target cr].
	target print:'%%Pages: '; write: pages; cr.
	target
		print: '%%EOF';
		cr