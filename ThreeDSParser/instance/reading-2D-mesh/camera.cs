camera
	"Subchunk of namedObject"

	| cameraSpec |
	cameraSpec _ Dictionary new.
	cameraSpec at: #position put: self vector3.
	cameraSpec at: #target put: self vector3.
	cameraSpec at: #roll put: self float.
	cameraSpec at: #focal put: self float.
	"May be followed by near/far range"
	self recognize: #((16r4720 twoFloats)) do: [:item | 
		cameraSpec at: #near put: item first.
		cameraSpec at: #far put: item second].
	^self cameraClass from3DS: cameraSpec