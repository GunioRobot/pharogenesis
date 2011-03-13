eToyStreamedRepresentationNotifying: aWidget

	| safeVariant outData |

	self flag: #bob.		"probably irrelevant"
	safeVariant := self copy.
	[ outData := SmartRefStream streamedRepresentationOf: safeVariant ] 
		on: ProgressInitiationException
		do: [ :ex | 
			ex sendNotificationsTo: [ :min :max :curr |
				aWidget ifNotNil: [aWidget flashIndicator: #working].
			].
		].
	^outData
