eToyStreamedRepresentationNotifying: aWidget

	| safeVariant outData |

	self flag: #bob.		"probably irrelevant"
	safeVariant _ self copy.
	[ outData _ SmartRefStream streamedRepresentationOf: safeVariant ] 
		on: ProgressInitiationException
		do: [ :ex | 
			ex sendNotificationsTo: [ :min :max :curr |
				aWidget ifNotNil: [aWidget flashIndicator: #working].
			].
		].
	^outData
