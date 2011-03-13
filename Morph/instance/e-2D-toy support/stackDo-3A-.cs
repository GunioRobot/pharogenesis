stackDo: aBlock
	"If the receiver has a stack, evaluate aBlock on its behalf"

	| aStack |
	(aStack _ self ownerThatIsA: StackMorph) ifNotNil:
		[^ aBlock value: aStack]