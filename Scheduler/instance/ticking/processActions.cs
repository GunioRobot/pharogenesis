processActions
	"This method executes every active action and removes any that done"

	actionList do: [:action | action execute.
							(action isDone) ifTrue: [self removeAction: action]
				].
