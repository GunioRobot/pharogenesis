readColorTable: numberOfEntries

	| array r g b |

	array _ Array new: numberOfEntries.
	1 to: array size do: [ :i |
		r _ self next.  
		g _ self next.  
		b _ self next.
		array at: i put: (Color r: r g: g b: b range: 255)
	].
	^array