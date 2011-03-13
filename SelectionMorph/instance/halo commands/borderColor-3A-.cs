borderColor: aColor

	| bordered |
	bordered _ selectedItems select: [:m | m isKindOf: BorderedMorph].
	undoProperties ifNil: [undoProperties _ bordered collect: [:m | m borderColor]].
	bordered do: [:m | m borderColor: aColor]