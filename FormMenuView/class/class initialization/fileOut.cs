fileOut
	"Save the FormEditor button icons."
	"FormMenuView fileOut"

	| names |
	names := 
		#('select.form' 'singlecopy.form' 'repeatcopy.form' 'line.form' 'curve.form'
		'block.form' 'over.form' 'under.form' 'reverse.form' 'erase.form' 'in.form'
		'magnify.form' 'white.form' 'lightgray.form' 'gray.form' 'darkgray.form' 'black.form'
		'xgrid.form' 'ygrid.form' 'togglegrids.form' 'out.form').
	1 to: FormButtons size do: [:i |
		(FormButtons at: i) form writeOnFileNamed: (names at: i)].
	SpecialBorderForm writeOnFileNamed: 'specialborderform.form'.
	BorderForm writeOnFileNamed: 'borderform.form'.
