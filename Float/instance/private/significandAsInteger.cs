significandAsInteger

	| exp |
	exp _ self exponent max: -1022.
	^ (self timesTwoPower: (52 - exp)) asInteger