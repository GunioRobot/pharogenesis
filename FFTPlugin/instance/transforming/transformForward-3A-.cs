transformForward: forward
	| lev lev1 ip theta realU imagU realT imagT i fftSize2 fftSize4 fftScale ii |
	self var: #realU declareC:'float realU'.
	self var: #realT declareC:'float realT'.
	self var: #imagU declareC:'float imagU'.
	self var: #imagT declareC:'float imagT'.
	fftSize2 _ fftSize // 2.
	fftSize4 _ fftSize // 4.
	1 to: nu do:
		[:level |
		lev _ 1 bitShift: level.
		lev1 _ lev // 2.
		fftScale _ fftSize // lev.
		1 to: lev1 do:
			[:j |
			theta _ j-1 * fftScale.   "pi * (j-1) / lev1 mapped onto 0..n/2"
			theta < fftSize4  "Compute U, the complex multiplier for each level"
				ifTrue:
					[realU _ sinTable at: sinTableSize - theta - 1.
					imagU _ sinTable at: theta]
				ifFalse:
					[realU _ 0.0 - (sinTable at: theta - fftSize4).
					imagU _ sinTable at: fftSize2 - theta].
			forward ifFalse: [imagU _ 0.0 - imagU].
"
			Here is the inner loop...
			j to: n by: lev do:
				[:i |   hand-transformed to whileTrue...
"
			i _ j.
			[i <= fftSize] whileTrue:
				[ip _ i + lev1 - 1.
				ii _ i-1.
				realT _ ((realData at: ip) * realU) - ((imagData at: ip) * imagU).
				imagT _ ((realData at: ip) * imagU) + ((imagData at: ip) * realU).
				realData at: ip put: (realData at: ii) - realT.
				imagData at: ip put: (imagData at: ii) - imagT.
				realData at: ii put: (realData at: ii) + realT.
				imagData at: ii put: (imagData at: ii) + imagT.
				i _ i + lev]]].