stacksRow
	| row |

	row := (AlignmentMorph newRow)
		vResizing: #spaceFill;
		hResizing: #spaceFill;
		centering: #topLeft;
		color: Color transparent;
		yourself.
	self stacks do: [:stack |
		row 
			addMorphBack: AlignmentMorph newVariableTransparentSpacer;
			addMorphBack: stack].
	row addMorphBack: AlignmentMorph newVariableTransparentSpacer.
	^row