deselectSelection

	selection ifNotNil:
		[selection do: [:loc | (self tileAt: loc) setSwitchState: false; color: selectionColor].
		selection _ nil.
		flash _ false]