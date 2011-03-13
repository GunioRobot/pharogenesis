layoutPanes
	| widths rect |
	widths _ self computeMorphWidths.
	rect _ 0@0 extent: (0 @ self paneHeight).
	transform submorphs 
					with: widths 
					do: [:m :w | 
						rect _ rect withWidth: w.
						m bounds: rect.
						rect _ rect translateBy: (w@0)]
						
