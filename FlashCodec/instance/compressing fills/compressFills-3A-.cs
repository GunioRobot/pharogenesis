compressFills: anArray
	stream print: anArray size.
	anArray do:[:fillStyle| self compressFillStyle: fillStyle].
	stream nextPut:$X. "Terminator"