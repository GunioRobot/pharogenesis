initDither8Lookup	
	self inline: false. 
	0 to: 255 do: [:b | 
		0 to: 15 do: [:t | | value |
			value _ self expensiveDither32To16: b threshold: t.
			dither8Lookup at: ((t << 8)+b)put: value]].
	