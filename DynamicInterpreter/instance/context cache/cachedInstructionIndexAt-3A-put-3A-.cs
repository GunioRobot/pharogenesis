cachedInstructionIndexAt: cp put: anInteger
	"Only for use in situations where the transformation of representation is required."

	self inline: true.
	self assertIsIntegerObject: anInteger.
	self cachedInstructionPointerAt: cp
		put: (self translatedInstructionIndex: anInteger
					toPointerIn: (self cachedTranslatedMethodAt: cp)).