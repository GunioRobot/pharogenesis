decompressSound: aByteArray stereo: stereo samples: numSamples rate: samplingRate into: buffers
	| data nBits signMask indexTable channels valPred index vp idx delta step vpdiff allButSignMask k k0 |
	data := FlashFileStream on: (ReadStream on: aByteArray).
	data initBits.
	nBits := (data nextBits: 2) + 2.
	signMask := 1 bitShift: nBits - 1.
	allButSignMask := signMask bitInvert32.
	k0 := 1 bitShift: (nBits - 2).
	indexTable := IndexTables at: nBits - 1.
	channels := stereo ifTrue:[2] ifFalse:[1].
	valPred := IntegerArray new: channels.
	index := IntegerArray new: channels.
	1 to: numSamples do:[:nOut|
		(nOut bitAnd: 16rFFF) = 1 ifTrue:["New block header starts every 4KB"
			1 to: channels do:[:i|
				vp := data nextSignedBits: 16.
				valPred at: i put: vp.
				(buffers at: i) nextPut: vp.
				"First sample has no delta"
				index at: i put: (data nextBits: 6).
			].
		] ifFalse:[ "Decode next sample"
			1 to: channels do:[:i|
				vp := valPred at: i.
				idx := index at: i.
				"Get next delta value"
				delta := data nextBits: nBits.
				"Compute difference and new predicted value"
				"Computes 'vpdiff = (delta+0.5)*step/4"
				step := StepTable at: idx + 1.
				k := k0.
				vpdiff := 0.
				[	(delta bitAnd: k) = 0 ifFalse:[vpdiff := vpdiff + step].
					step := step bitShift: -1.
					k := k bitShift: -1.
					k = 0] whileFalse.
				vpdiff := vpdiff + step.
				(delta anyMask: signMask) 
					ifTrue:[vp := vp - vpdiff]
					ifFalse:[vp := vp + vpdiff].
				"Compute new index value"
				idx := idx + (indexTable at: (delta bitAnd: allButSignMask) + 1).
				"Clamp index"
				idx < 0 ifTrue:[idx := 0].
				idx > 88 ifTrue:[idx := 88].
				"Clamp output value"
				vp < -32768 ifTrue:[vp := -32768].
				vp > 32767 ifTrue:[vp := 32767].
				"Store values back"
				index at: i put: idx.
				valPred at: i put: vp.
				(buffers at: i) nextPut: vp.
			]
		].
	].