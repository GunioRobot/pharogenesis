unhighlightSelection
	| unhighlightColor columnLength localIndex m previousSelectedIndex |
	unhighlightColor _ Color black.
	selectedMorph
		ifNotNil: [selectedMorph color: unhighlightColor;
				 changed.
			previousSelectedIndex _ scroller submorphs
						findFirst: [:mp | mp contents = selectedMorph contents].
			columnLength _ lists first size.
			2
				to: lists size
				do: [:columnIndex | 
					localIndex _ previousSelectedIndex + (columnLength * (columnIndex - 1)).
					localIndex = 0 ifFalse: [
						m _ scroller submorphs asArray at: localIndex.
						m color: unhighlightColor;
						 	changed]]]