includesKey: aKey ifTrue: trueBlock ifFalse: falseBlock
	"If the receiver includes the given key, evaluate trueBlock, else evaluate falseBlock.  6/7/96 sw"

	self noteToDan.  "After the three hundredth time I submitted a method as if this glue existed, and then had to put parentheses around the includesKey: clause, I though it might be expedient to have this crutch available.  However, perhaps one could think of it as damaging because it would tempt people to assume you could do this elsewhere?!  What do you think?"

	^ (self includesKey: aKey)
		ifTrue:
			[trueBlock value]
		ifFalse:
			[falseBlock value]