matrix
	"float matrix[4][3]"
	
	| m |
	m := B3DMatrix4x4 identity.
	1 to: 4 do: [:column |
		1 to: 3 do: [:row |
			m basicAt: row-1*4+column put: self uLong.
			"m row: row column: column put: source readFloat"]].
	^m