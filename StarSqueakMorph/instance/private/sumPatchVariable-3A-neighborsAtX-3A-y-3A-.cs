sumPatchVariable: patchVarName neighborsAtX: xPos y: yPos
	"Answer the sum of the given patch variable for the eight neighbors of the patch at the given location. Answer zero if the location is out of bounds."

	| patchVar x y w h xLeft xRight rowOffset sum |
	patchVar := patchVariables at: patchVarName ifAbsent: [^ 0].
	x := xPos truncated.
	y := yPos truncated.
	w := dimensions x.
	h := dimensions y.
	((x < 0) or: [y < 0]) ifTrue: [^ 0].
	((x >= w) or: [y >= h]) ifTrue: [^ 0].
	xLeft := (x - 1) \\ w.  "column before x, wrapped"
	xRight := (x + 1) \\ w.  "column after x, wrapped"
	rowOffset := y * w.
	sum :=
		(patchVar at: rowOffset + xLeft) +
		(patchVar at: rowOffset + xRight).
	rowOffset := ((y - 1) \\ h) * w.  "row above y, wrapped"
	sum := sum +
		(patchVar at: rowOffset + xLeft) +
		(patchVar at: rowOffset + x) +
		(patchVar at: rowOffset + xRight).
	rowOffset := ((y + 1) \\ h) * w.  "row below y, wrapped"
	sum := sum +
		(patchVar at: rowOffset + xLeft) +
		(patchVar at: rowOffset + x) +
		(patchVar at: rowOffset + xRight).
	^ sum

