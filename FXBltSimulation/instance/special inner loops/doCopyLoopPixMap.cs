doCopyLoopPixMap
	self inline: true.
	sourceMSB ifTrue:[
		destMSB 
			ifTrue:[self copyLoopPixMapMsbMsb]
			ifFalse:[self copyLoopPixMapMsbLsb]
	] ifFalse:[
		destMSB
			ifTrue:[self copyLoopPixMapLsbMsb]
			ifFalse:[self copyLoopPixMapLsbLsb]
	].