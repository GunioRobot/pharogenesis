doWarpLoop
	self inline: true.
	sourceMSB ifTrue:[
		destMSB 
			ifTrue:[self warpLoopMsbMsb]
			ifFalse:[self warpLoopMsbLsb]
	] ifFalse:[
		destMSB
			ifTrue:[self warpLoopLsbMsb]
			ifFalse:[self warpLoopLsbLsb]
	].