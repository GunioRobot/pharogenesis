chooseSamplePitch: evt
	| menu |
	menu _ MenuMorph new.
	#(c1 g1 c2 g2 c3 g3 c4 g4 c5 g5 c6 g6 c7 g7 c8 g8) do:
		[:picthName |
		menu add: picthName
			target: self selector: #setSamplePitch:
			argument: picthName].
	menu popUpAt: evt hand position event: evt.
