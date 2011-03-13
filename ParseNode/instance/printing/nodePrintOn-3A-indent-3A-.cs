nodePrintOn: aStrm indent: nn
	| var aaStrm myLine |
	"Show just the sub nodes and the code."

	(aaStrm _ aStrm) ifNil: [aaStrm _ WriteStream on: (String new: 500)].
	nn timesRepeat: [aaStrm tab].
	aaStrm nextPutAll: self class name; space.
	myLine _ self printString copyWithout: Character cr.
	myLine _ myLine copyFrom: 1 to: (myLine size min: 70).
	aaStrm nextPutAll: myLine; cr.
	1 to: self class instSize do: [:ii | 
		var _ self instVarAt: ii.
		(var respondsTo: #asReturnNode) ifTrue: [var nodePrintOn: aaStrm indent: nn+1]].
	1 to: self class instSize do: [:ii | 
		var _ self instVarAt: ii.
		(var isKindOf: SequenceableCollection) ifTrue: [
				var do: [:aNode | 
					(aNode respondsTo: #asReturnNode) ifTrue: [
						aNode nodePrintOn: aaStrm indent: nn+1]]]].
	^ aaStrm
