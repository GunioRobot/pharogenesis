initialize
	"TilePadMorph initialize"

	ColorsForType _ IdentityDictionary new.
	#(	
	(command		(0.065 0.258 1.0)		(0.065 0.258 1.0))
	(number		(0.8 0.4 0.2)			(1.0	0.6 0.2))
	(boolean		(0.94 1.0 0.06)		(0.94 1.0 0.06))  		"some kind of yellowish"
	(player			(1.0  0 0.065)		(1.0  0 0.065)) 
	(color			(1.0  0 0.065)		(0.806 1.0 0.806))  	"some damn dark red"
	(sound			(1.0 0.06 0.84)		(1.0 0.06 0.84))   	"a kind of magenta"
	(point			(1.0 0.26 0.98)		(1.0 0.26 0.98))   	"arbitrary"
	(rotationStyle	(1.0 0.26 0.98)		(1.0 0.26 0.98))   	"arbitrary"

	(string			(0.0 0.0 1.0)			(0.0 0.0 1.0))      "not in use"
	(group			(0.0 0.0 1.0)			(0.0 0.0 1.0))		 "not in use"
	(costume		(0.806 1.0 0.806)	(0.806 1.0 0.806))		 "not in use")		

	do:
		[:t | ColorsForType at: t first put:
			(Array 	with: 	((Color fromRgbTriplet: t second) mixed: self colorFudge with: ScriptingSystem uniformTileInteriorColor)
					with:	(Color fromRgbTriplet: t third))]