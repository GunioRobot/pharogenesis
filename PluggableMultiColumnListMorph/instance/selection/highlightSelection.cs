highlightSelection
	| highlightColor columnLength localIndex m properSelectedIndex |
	highlightColor _ Color red.
	"<-- Change the highlight color here."
	selectedMorph
		ifNotNil: [selectedMorph color: highlightColor;
				 changed.
			properSelectedIndex _ scroller submorphs
						findFirst: [:mp | mp contents = selectedMorph contents].
			selectedIndex = properSelectedIndex ifFalse: [selectedIndex _ properSelectedIndex].
			columnLength _ lists first size.
			2
				to: lists size
				do: [:columnIndex | 
					localIndex _ selectedIndex + (columnLength * (columnIndex - 1)).
					m _ scroller submorphs asArray at: localIndex.
					m color: highlightColor;
						 changed]]