borderWidth: aWidth

	| bordered |
	bordered _ selectedItems select: [:m | m isKindOf: BorderedMorph].
	undoProperties ifNil: [undoProperties _ bordered collect: [:m | m borderWidth]].
	bordered do: [:m | m borderWidth: aWidth]