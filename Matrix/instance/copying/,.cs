, aMatrix
	"Answer a new matrix having the same number of rows as the receiver and aMatrix,
	 its columns being the columns of the receiver followed by the columns of aMatrix."
	|newCont newCols anArray oldCols a b c|

	self assert: [nrows = aMatrix rowCount].
	newCont _ Array new: self size + aMatrix size.
	anArray _ aMatrix privateContents.
	oldCols _ aMatrix columnCount.
	newCols _ ncols + oldCols.
	a _ b _ c _ 1.
	1 to: nrows do: [:r |
		newCont replaceFrom: a to: a+ncols-1 with: contents startingAt: b.
		newCont replaceFrom: a+ncols to: a+newCols-1 with: anArray startingAt: c.
		a _ a + newCols.
		b _ b + ncols.
		c _ c + oldCols].
	^self class rows: nrows columns: newCols contents: newCont
		
