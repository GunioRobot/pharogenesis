cachedStackIndexAt: cp put: anInteger

	self inline: true.
	self assertIsIntegerObject: anInteger.
	self cachedStackPointerAt: cp put: (self cachedFramePointerAt: cp) + (((self integerValueOf: anInteger) - 1) * 4)