specializeLoopsIn: cg
	"FXBltScanner translate"
	"Specialize those loops that benefit from a distinction of LSB vs. MSB variants"
	| i s |
	'Specializing inner loops' 
		displayProgressAt: Sensor cursorPoint
		from: 1 to: 8 during:[:bar|
	i _ 0.
	{true. false} do:[:srcMsb|
		{true. false} do:[:dstMsb|
			#(copyLoopPixMap warpLoop) do:[:sel|
				bar value: (i_i+1).
				s _ sel, (srcMsb ifTrue:['Msb'] ifFalse:['Lsb']),
							(dstMsb ifTrue:['Msb'] ifFalse:['Lsb']).
				s _ s asSymbol.
				cg specializeMethod: s variable: 'sourceMSB' value: srcMsb.
				cg specializeMethod: s variable: 'destMSB' value: dstMsb]]].
	].