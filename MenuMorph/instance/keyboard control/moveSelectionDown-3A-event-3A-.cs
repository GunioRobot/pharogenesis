moveSelectionDown: direction event: evt
	"Move the current selection up or down by one, presumably under keyboard control.
	direction = +/-1"

	| index m |
	index _ (submorphs indexOf: selectedItem ifAbsent: [1-direction]) + direction.
	submorphs do: "Ensure finite"
		[:unused | m _ submorphs atWrap: index.
		((m isKindOf: MenuItemMorph) and: [m isEnabled]) ifTrue:
			[^ self selectItem: m event: evt].
		"Keep looking for an enabled item"
		index _ index + direction sign].
	^ self selectItem: nil event: evt