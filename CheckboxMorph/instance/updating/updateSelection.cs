updateSelection
	"Update the selection state."

	self buttonMorph ifNotNilDo: [:m | m selected: self isSelected].
	self changed: #isSelected