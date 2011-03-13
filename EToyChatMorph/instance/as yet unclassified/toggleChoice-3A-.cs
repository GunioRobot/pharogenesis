toggleChoice: aSymbol
	
	aSymbol == #acceptOnCR ifTrue: [
		acceptOnCR _ (acceptOnCR ifNil: [true]) not.
		sendingPane ifNotNil: [sendingPane acceptOnCR: acceptOnCR].
		^self
	].

