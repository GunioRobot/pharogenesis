defaultNameStemForInstances
	"Answer a basis for names of default instances of the receiver."
	^myName ifNil:[super defaultNameStemForInstances].