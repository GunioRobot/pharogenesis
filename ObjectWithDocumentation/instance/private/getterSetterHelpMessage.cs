getterSetterHelpMessage
	"Returns a helpMessage that has been computed previously and needs to be translated and then formatted with the elementSymbol.
	'get value of {1}' translated format: {elSym}"

	^(self propertyAt: #getterSetterHelpMessage ifAbsent: [^nil])
		translated format: {self elementSymbol}