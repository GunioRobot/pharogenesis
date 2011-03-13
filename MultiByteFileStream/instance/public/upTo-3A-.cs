upTo: delim 
	| out ch collectorClass |
	collectorClass := self isBinary
				ifTrue: [ByteArray]
				ifFalse: [String].
	out := (collectorClass new: 1000) writeStream.
	[(ch := self next) isNil]
		whileFalse: [ch = delim
				ifTrue: [^ out contents].
			out nextPut: ch].
	^ out contents