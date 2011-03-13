valueWithWorld: aWorldOrNil

	^self
		on: RequestCurrentWorldNotification
		do: [ :ex | ex resume: aWorldOrNil ]