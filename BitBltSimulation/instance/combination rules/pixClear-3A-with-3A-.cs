pixClear: sourceWord with: destinationWord
	"Clear all pixels in destinationWord for which the pixels of sourceWord have the same values. Used to clear areas of some constant color to zero."
	| mask result nBits pv |
	self inline: false.
	destDepth = 32 ifTrue:[
		sourceWord = destinationWord ifTrue:[^0] ifFalse:[^destinationWord].
	].
	nBits := destDepth.
	mask _ maskTable at: nBits.  "partition mask starts at the right"
	result _ 0.
	1 to: destPPW do:[:i |
		pv := destinationWord bitAnd: mask.
		(sourceWord bitAnd: mask) = pv ifTrue:[pv := 0].
		result := result bitOr: pv.
		mask := mask << nBits "slide left to next partition"].
	^ result