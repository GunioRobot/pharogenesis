preMultiplyByMatrix: m
	"Answer m+*self where m is a Matrix."

	m columnCount = self size ifFalse: [self error: 'dimensions do not conform'].
	^(1 to: m rowCount) collect: [:row | | s |
		s := 0.
		1 to: self size do: [:k | s := (m at: row at: k) * (self at: k) + s].
		s]