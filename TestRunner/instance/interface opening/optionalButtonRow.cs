optionalButtonRow
	| row btn |
	row _ AlignmentMorph newRow.
	row beSticky.
	row hResizing: #spaceFill.
	row wrapCentering: #center;
		 cellPositioning: #leftCenter.
	row clipSubmorphs: true.
	row cellInset: 3.
	self optionalButtonPairs
		do: [:pair | 
		btn _ PluggableButtonMorph on: self getState: nil action: pair second.
		btn useRoundedCorners; hResizing: #spaceFill; vResizing: #spaceFill; onColor: Color transparent offColor: Color transparent;
		label: pair first.
		row addMorphBack: btn
		].
	^ row