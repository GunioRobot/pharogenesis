sortBlock: aBlock 
	"Make the argument, aBlock, be the criterion for ordering elements of the 
	receiver."

	aBlock
		ifNotNil: [sortBlock := aBlock fixTemps]
		ifNil: [sortBlock := aBlock].
	"The sortBlock must copy its home context, so as to avoid circularities!"
	"Therefore sortBlocks with side effects may not work right"
	self size > 0 ifTrue: [self reSort]