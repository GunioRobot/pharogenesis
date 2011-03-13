justDroppedIntoPianoRoll: newOwner event: evt
	
	| startX lengthInTicks endX startTimeInScore endTimeInScore |

	super justDroppedIntoPianoRoll: newOwner event: evt.

	startTimeInScore _ newOwner timeForX: self left.
	lengthInTicks _ newOwner scorePlayer ticksForMSecs: self myDurationInMS.
	endTimeInScore _ startTimeInScore + lengthInTicks.

	endTimeInScore > newOwner scorePlayer durationInTicks ifTrue:
		[newOwner scorePlayer updateDuration].

	startX _ newOwner xForTime: startTimeInScore.
	endX _ newOwner xForTime: endTimeInScore.
	self width: endX - startX.
