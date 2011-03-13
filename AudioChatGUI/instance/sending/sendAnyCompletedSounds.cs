sendAnyCompletedSounds

	| soundsSoFar firstCompleteSound |

	myrecorder isRecording ifFalse: [^self].
	mytargetip isEmpty ifTrue: [^self].
	soundsSoFar _ myrecorder recorder recordedSound ifNil: [^self].
	firstCompleteSound _ soundsSoFar removeFirstCompleteSoundOrNil ifNil: [^self].
	self sendOneOfMany: firstCompleteSound.