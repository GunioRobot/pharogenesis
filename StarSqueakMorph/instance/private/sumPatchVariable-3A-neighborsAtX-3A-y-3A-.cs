sumPatchVariable: patchVarName neighborsAtX: xPos y: yPos
	"Answer the sum of the given patch variable for the eight neighbors of the patch at the given location. Answer zero if the location is out of bounds."

	| patchVar x y w h xLeft xRight rowOffset sum |
	patchVar _ patchVariables at: patchVarName ifAbsent: [^ 0].
	x _ xPos truncated.
	y _ yPos truncated.
	w _ dimensions x.
	h _ dimensions y.
	((x < 0) or: [y < 0]) ifTrue: [^ 0].
	((x >= w) or: [y >= h]) ifTrue: [^ 0].
	xLeft _ (x - 1) \\ w.  "column before x, wrapped"
	xRight _ (x + 1) \\ w.  "column after x, wrapped"
	rowOffset _ y * w.
	sum _
		(patchVar at: rowOffset + xLeft) +
		(patchVar at: rowOffset + xRight).
	rowOffset _ ((y - 1) \\ h) * w.  "row above y, wrapped"
	sum _ sum +
		(patchVar at: rowOffset + xLeft) +
		(patchVar at: rowOffset + x) +
		(patchVar at: rowOffset + xRight).
	rowOffset _ ((y + 1) \\ h) * w.  "row below y, wrapped"
	sum _ sum +
		(patchVar at: rowOffset + xLeft) +
		(patchVar at: rowOffset + x) +
		(patchVar at: rowOffset + xRight).
	^ sum

