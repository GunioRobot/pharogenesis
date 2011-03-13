eToyStreamedRepresentationNotifying: aWidget

	| outData |
	[ outData _ SmartRefStream streamedRepresentationOf: self ] 
		on: ProgressInitiationException
		do: [ :ex | 
			ex sendNotificationsTo: [ :min :max :curr |
				aWidget ifNotNil: [aWidget flashIndicator: #working].
			].
		].
	^outData
