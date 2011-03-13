selectorsReachableFrom: selector
	"Answer the Set of selectors reachable transitively in Interpreter starting at selector"
	"InterpreterSupportCode selectorsReachableFrom: #primitiveAdd"

	| method messages prevSize |
	method _ Interpreter compiledMethodAt: selector.
	messages _ (method literals select: [:sel | Interpreter includesSelector: sel]) asSet.
	prevSize _ 0.
	[messages size > prevSize] whileTrue:
		[prevSize _ messages size.
		 messages copy do: [:sel |
			method _ Interpreter compiledMethodAt: sel.
			messages addAll: (method literals select: [:sel2 | Interpreter includesSelector: sel2])]].
	^messages add: selector; yourself