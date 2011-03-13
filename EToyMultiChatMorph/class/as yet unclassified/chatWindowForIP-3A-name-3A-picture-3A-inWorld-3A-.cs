chatWindowForIP: ipAddress name: senderName picture: aForm inWorld: aWorld

	^self allInstances 
		detect: [ :x | x world == aWorld] 
		ifNone: [
			EToyCommunicatorMorph playArrivalSound.
			self new open
		].

