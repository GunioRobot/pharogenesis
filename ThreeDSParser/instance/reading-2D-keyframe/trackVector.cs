trackVector

	"Read keyframes interpolating a vector (position, scale)"
	| vector spec splClass |
	^self trackCollect: [:params|
		params ifNil:[spec _ Dictionary new] ifNotNil:[spec _ params].
		vector := self vector3.
		spec at: #position put: vector.
		log == nil ifFalse: [log print: vector].
		splClass _ self splineVertexClass.
		splClass
			ifNil:[vector]
			ifNotNil:[splClass from3DS: spec]].