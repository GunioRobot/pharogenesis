transformForward: forward
	| lev lev1 ip theta realU imagU realT imagT i |
	self permuteData.
	1 to: nu do:
		[:level |
		lev _ 1 bitShift: level.
		lev1 _ lev // 2.
		1 to: lev1 do:
			[:j |
			theta _ j-1 * (n // lev).   "pi * (j-1) / lev1 mapped onto 0..n/2"
			theta < (n//4)  "Compute U, the complex multiplier for each level"
				ifTrue:
					[realU _ sinTable at: sinTable size - theta.
					imagU _ sinTable at: theta + 1]
				ifFalse:
					[realU _ (sinTable at: theta - (n//4) + 1) negated.
					imagU _ sinTable at: (n//2) - theta + 1].
			forward ifFalse: [imagU _ imagU negated].
"
			Here is the inner loop...
			j to: n by: lev do:
				[:i |   hand-transformed to whileTrue...
"
			i _ j.
			[i <= n] whileTrue:
				[ip _ i + lev1.
				realT _ ((realData at: ip) * realU) - ((imagData at: ip) * imagU).
				imagT _ ((realData at: ip) * imagU) + ((imagData at: ip) * realU).
				realData at: ip put: (realData at: i) - realT.
				imagData at: ip put: (imagData at: i) - imagT.
				realData at: i put: (realData at: i) + realT.
				imagData at: i put: (imagData at: i) + imagT.
				i _ i + lev]]].
	forward ifFalse: [self scaleData]  "Reverse transform must scale to be an inverse"