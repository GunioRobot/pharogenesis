sendSelectorToClass: classPointer
	"Note: Requires that instructionPointer and stackPointer be externalized."

	self inline: true.
	self findNewMethodInClass: classPointer.
	self executeNewMethod.
