width: aNumber
	width = aNumber ifTrue:[^self].
	width _ aNumber truncated max: (width isPoint ifTrue:[0@0] ifFalse:[0]).
	self releaseCachedState.