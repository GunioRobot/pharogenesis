trigger: anEventSymbol
	"Evaluate all message sends registered for anEventSymbol."

	((self myEvents ifNil: [^ self])
		at: anEventSymbol ifAbsent: [^ self])
			do: [:each | each value]