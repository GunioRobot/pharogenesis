newObjectFromStream: dataStream

	| newObject |

	[newObject _ SmartRefStream objectFromStreamedRepresentation: dataStream upToEnd.]
		on: ProgressInitiationException
		do: [ :ex | 
			ex sendNotificationsTo: [ :min :max :curr |
				"self flashIndicator: #working."
			].
		].
	"self resetIndicator: #working."
	^newObject
