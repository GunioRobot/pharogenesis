trigger: anEventSymbol withArguments: anArray
	"Evaluate all message sends registered for anEventSymbol
	and pass anArray to the registered actions."

	((self myEvents ifNil: [^ self])
		at: anEventSymbol ifAbsent: [^ self])
			do: [:each | each valueWithArguments: anArray]