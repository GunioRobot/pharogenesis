carMotorSound: samplingRate
	"Return a repeating sound for the sound of a car engine. Different sampling rates give different motor sounds."
	"(RepeatingSound carMotorSound: 12050) play"

	CarMotorSamples ifNil: [self initializeCarMotor].
	^ RepeatingSound repeatForever:
		(SampledSound samples: CarMotorSamples samplingRate: samplingRate)
