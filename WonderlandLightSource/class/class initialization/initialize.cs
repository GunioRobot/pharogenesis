initialize
	"Add the light names to WonderlandConstants"
	| dict |
	dict _ Smalltalk at: #WonderlandConstants.
	#(ambient positional directional spotlight) do:[:each| 
		dict declare: each from: Undeclared.
		dict at: each put: each.
	].