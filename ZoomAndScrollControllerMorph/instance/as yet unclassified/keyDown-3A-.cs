keyDown: anEvent

	changeKeysState ifNotNil: [
		upDownCodes at: anEvent keyValue put: changeKeysState first.
		changeKeysState _ changeKeysState allButFirst.
		changeKeysState isEmpty ifTrue: [changeKeysState _ nil].
		currentKeyDown _ Set new.
		^self changed
	].
	currentKeyDown add: anEvent keyValue.
