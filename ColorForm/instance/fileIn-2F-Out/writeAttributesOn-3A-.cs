writeAttributesOn: file
	| colorArray |
	super writeAttributesOn: file.
	colorArray _ self colors asColorArray.
	1 to: (2 raisedTo: depth) do: [:idx |
		file nextLittleEndianNumber: 4 put: (colorArray basicAt: idx).
	] 