borderColor: aColor

	| bordered |
	bordered _ selectedItems.
	undoProperties ifNil: [undoProperties _ bordered collect: [:m | m borderColor]].
	bordered do: [:m | m borderColor: aColor]