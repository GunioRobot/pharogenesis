encodeBitLength: blCounts from: aTree
	| index |
	"Note: If bitLength is not nil then the tree must be broken"
	bitLength == nil ifFalse:[self error:'Huffman tree is broken'].
	parent = nil 
		ifTrue:[bitLength _ 0]
		ifFalse:[bitLength _ parent bitLength + 1].
	self isLeaf ifTrue:[
		index _ bitLength + 1.
		blCounts at: index put: (blCounts at: index) + 1.
	] ifFalse:[
		left encodeBitLength: blCounts from: aTree.
		right encodeBitLength: blCounts from: aTree.
	].