preMultiplyByMatrix: m
	"Answer m+*self where m is a Matrix."
	|s|

	m columnCount = self size ifFalse: [self error: 'dimensions do not conform'].
	^(1 to: m rowCount) collect: [:row |
		s _ 0.
		1 to: self size do: [:k | s _ (m at: row at: k) * (self at: k) + s].
		s]