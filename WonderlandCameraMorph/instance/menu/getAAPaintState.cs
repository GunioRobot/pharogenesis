getAAPaintState
	^self aaPaintingEnabled
		ifTrue:['<on>antialiased texture painting']
		ifFalse:['<off>antialiased texture painting']
