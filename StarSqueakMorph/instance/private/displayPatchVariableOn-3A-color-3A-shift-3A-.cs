displayPatchVariableOn: aForm color: aColor shift: shiftAmount 
	"Display patchVariableToDisplay in the given color. The opacity (alpha) of of each patch is determined by the patch variable value for that patch and shiftAmount. If shiftAmount is zero, the source value is unscaled. Positive shiftAmount values result in right shifting the source value by the given number of bits (That is, multiplying by 2^N. Negative values perform right shifts, dividing by 2^N)."

	| patchVar bitBlt w rowOffset alpha |
	patchVariableToDisplay ifNil: [^self].
	patchVar := patchVariables at: patchVariableToDisplay ifAbsent: [^self].

	"set up the BitBlt"
	bitBlt := (BitBlt toForm: aForm)
				sourceRect: (0 @ 0 extent: pixelsPerPatch);
				fillColor: aColor;
				combinationRule: 30.
	w := dimensions x.
	0 to: dimensions y - 1
		do: 
			[:y | 
			rowOffset := y * w + 1.
			0 to: w - 1
				do: 
					[:x | 
					alpha := (patchVar at: rowOffset + x) bitShift: shiftAmount.
					alpha := alpha min: 255.
					alpha > 1 
						ifTrue: 
							["if not transparent, fill using the given alpha"

							bitBlt destOrigin: (x * pixelsPerPatch) @ (y * pixelsPerPatch).
							bitBlt copyBitsTranslucent: alpha]]]