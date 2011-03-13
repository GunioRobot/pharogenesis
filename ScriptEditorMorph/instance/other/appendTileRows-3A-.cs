appendTileRows: tileRows
	"Append the given rows of tiles to my script."

	tileRows do: [:r | self insertTileRow: r after: submorphs size].
	self removeSpaces.
