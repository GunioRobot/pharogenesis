startOfTyping
	"Compatibility during change from characterBlock to integer"
	beginTypeInBlock == nil ifTrue: [^ nil].
	beginTypeInBlock isNumber ifTrue: [^ beginTypeInBlock].
	"Last line for compatibility during change from CharacterBlock to Integer."
	^ beginTypeInBlock stringIndex
	