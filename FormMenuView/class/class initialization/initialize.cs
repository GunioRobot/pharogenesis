initialize
	"The icons for the menu are typically stored on files. In order to avoid reading them every time, they are stored in a collection in a class variable, along with their offset, tool value, and initial visual state (on or off)."
	"FormMenuView initialize"

	| offsets keys states names button |
	offsets _ OrderedCollection new: 21.
	#(0 64 96 128 160 192 256 288 320 352 420) do: [:i | offsets addLast: i@0].  "First row"
	#(0 64 96 128 160 192 256 304 352 420) do: [:i | offsets addLast: i@48].  "Second row"
	offsets _ offsets asArray.
	keys _ #($a $s $d $f $g $h $j $k $l $; $' $z $x $c $v $b $n $m $, $. $/ ).  "Keyboard"
	states _ #(
		#false #false #true #false #false #false #true #false #false #false #false
		#false #false #false #false #false #true #false #false #false #false).  "Initial button states"
	names _ 
		#('select.form' 'singlecopy.form' 'repeatcopy.form' 'line.form' 'curve.form'
		'block.form' 'over.form' 'under.form' 'reverse.form' 'erase.form' 'in.form'
		'magnify.form' 'white.form' 'lightgray.form' 'gray.form' 'darkgray.form' 'black.form'
		'xgrid.form' 'ygrid.form' 'togglegrids.form' 'out.form').  "Files of button images"
	FormButtons _ OrderedCollection new.
	1 to: 21 do: [:index |
		button _ FormButtonCache new.
		button form: (Form fromFileNamed: (names at: index)).
		button offset: (offsets at: index).
		button value: (keys at: index).
		button initialState: (states at: index).
		FormButtons addLast: button].
	SpecialBorderForm  _ Form fromFileNamed: 'specialborderform.form'.
	BorderForm _ Form fromFileNamed: 'borderform.form'.
