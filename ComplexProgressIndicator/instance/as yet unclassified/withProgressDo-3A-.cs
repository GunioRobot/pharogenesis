withProgressDo: aBlock

	| safetyFactor totals trialRect delta stageCompletedString |

	Smalltalk isMorphic ifFalse: [^aBlock value].
	formerProject _ Project current.
	formerWorld _ World.
	formerProcess _ Processor activeProcess.
	targetMorph ifNil: [targetMorph _ ProgressTargetRequestNotification signal].
	targetMorph ifNil: [
		trialRect _ Rectangle center: Sensor cursorPoint extent: 80@80.
		delta _ trialRect amountToTranslateWithin: formerWorld bounds.
		trialRect _ trialRect translateBy: delta.
		translucentMorph _ TranslucentProgessMorph new
			opaqueBackgroundColor: Color white;
			bounds: trialRect;
			openInWorld: formerWorld.
	] ifNotNil: [
		translucentMorph _ TranslucentProgessMorph new
			setProperty: #morphicLayerNumber toValue: targetMorph morphicLayerNumber - 0.1;
			bounds: targetMorph boundsInWorld;
			openInWorld: targetMorph world.
	].
	stageCompleted _ 0.
	safetyFactor _ 1.1.	"better to guess high than low"
	translucentMorph setProperty: #progressStageNumber toValue: 1.
	totals _ self loadingHistoryDataForKey: 'total'.
	newRatio _ 1.0.
	estimate _ totals size < 2 ifTrue: [
		15000		"be a pessimist"
	] ifFalse: [
		(totals sum - totals max) / (totals size - 1 max: 1) * safetyFactor.
	].
	start _ Time millisecondClockValue.
	self forkProgressWatcher.

	[
		aBlock 
			on: ProgressInitiationException
			do: [ :ex | 
				ex sendNotificationsTo: [ :min :max :curr |
					"ignore this as it is inaccurate"
				].
			].
	] on: ProgressNotification do: [ :note |
		stageCompletedString _ (note messageText findTokens: ' ') first.
		stageCompleted _ (stageCompletedString copyUpTo: $:) asNumber.
		cumulativeStageTime _ Time millisecondClockValue - start max: 1.
		prevData _ self loadingHistoryDataForKey: stageCompletedString.
		prevData isEmpty ifFalse: [
			newRatio _ (cumulativeStageTime / (prevData average max: 1)) asFloat.
		].
		self 
			loadingHistoryAt: stageCompletedString 
			add: cumulativeStageTime.
		translucentMorph 
			setProperty: #progressStageNumber 
			toValue: stageCompleted + 1.
		note resume.
	].

	stageCompleted _ 999.	"we may or may not get here"

