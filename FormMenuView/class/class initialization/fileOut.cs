fileOut   "FormMenuView fileOut"
	"Save the FormEditor icons"
	| names |
	names _ 
		#('select.form.' 'singlecopy.form.' 'repeatcopy.form.' 'line.form.' 'curve.form.'
		'block.form' 'over.form.' 'under.form.' 'reverse.form.' 'erase.form.' 'in.form.'
		'magnify.form.' 'white.form' 'lightgray.form' 'gray.form' 'darkgray.form' 'black.form'
		'xgrid.form.' 'ygrid.form.' 'togglegrids.form.' 'out.form.' ).
	1 to: 21 do:  [:i |  (FormButtons at: i) writeOn: (names at: i)].
	SpecialBorderForm writeOn: 'specialborderform.form'.
	BorderForm writeOn: 'borderform.form'