alanUnaryPostRcvr: aNode key: key selector: selector

	| row |

	(self isStandardGetterSelector: key) ifTrue: [
		^self alanUnaryGetter: aNode key: key
	].
	row _ (self addUnaryRow: key style: #unary) layoutInset: 1.
	^ row parseNode: selector
