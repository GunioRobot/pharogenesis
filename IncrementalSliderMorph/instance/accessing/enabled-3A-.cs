enabled: aBoolean
	"Set whether the receiver is enabled for user input."

	self sliderMorph ifNotNilDo: [:sm | sm enabled: aBoolean].
	self
		changed: #enabled;
		changed: #minEnabled;
		changed: #maxEnabled