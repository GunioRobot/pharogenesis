wantsDroppedMorph: aMorph event: evt

	^ ((aMorph ~~ self) and: [aMorph ~~ Utilities scrapsBook]) and:
		[aMorph willingToBeDiscarded]