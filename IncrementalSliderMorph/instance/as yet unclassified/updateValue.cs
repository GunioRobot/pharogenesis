updateValue
	"Update the value."
	
	self model ifNotNil: [
		self getValueSelector ifNotNil: [
			self sliderMorph ifNotNilDo: [:sm |
				sm scaledValue: self value.
			self changed: #minEnabled; changed: #maxEnabled]]]