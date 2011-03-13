step

	| goForIt |

	actionBlock ifNil: [^self stopStepping].
	goForIt _ actionBlock.
	actionBlock _ nil.
	[
		goForIt value.
	]
		on: ProgressTargetRequestNotification
		do: [ :ex | ex resume: innerArea].		"in case a save/load progress display needs a home"
