fillStyle: aColor
	undoProperties ifNil: [undoProperties _ selectedItems collect: [:m | m fillStyle]].
	selectedItems do: [:m | m fillStyle: aColor]