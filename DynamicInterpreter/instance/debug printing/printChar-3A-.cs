printChar: aByte
	"For testing in Smalltalk, this method should be overridden in a subclass."

	self cCode: 'fputc(aByte, stderr)'