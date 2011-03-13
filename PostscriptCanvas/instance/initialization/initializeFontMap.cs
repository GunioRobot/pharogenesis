initializeFontMap
	"Initialize the dictionary mapping message names to actions for C code generation."

	| pairs |
	fontMap _ Dictionary new: 5.
	pairs _ #(
		'Palatino'  'Palatino-Roman'
		'NewYork' 'Helvetica'
		'NewYork-Bold' 'Helvetica-Bold'
		'ComicBold' 'Helvetica-Narrow-Bold'
	).

	1 to: pairs size by: 2 do: [:i |
		fontMap at: (pairs at: i) put: (pairs at: i + 1)].
