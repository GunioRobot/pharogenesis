defaultSystemConverter

	SystemConverterClass ifNil: [SystemConverterClass _ self currentPlatform class systemConverterClass].
	^ SystemConverterClass new.
