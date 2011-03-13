atRows: r1 to: r2 columns: c1 to: c2 ifInvalid: element
	"Answer a submatrix [r1..r2][c1..c2] of the receiver.
	 Portions of the result outside the bounds of the original matrix
	 are filled in with element."
	|rd cd|

	rd := r1 - 1.
	cd := c1 - 1.
	^self class rows: r2-rd columns: c2-cd tabulate: [:r :c| self at: r+rd at: c+cd ifInvalid: element]
