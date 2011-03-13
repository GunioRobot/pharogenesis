discardDiscards
	"Discard all discard* methods - including this one."

	(self class selectors select: [:each | each beginsWith: 'discard']) 
		do: [:each | self class removeSelector: each].
	#(lastRemoval majorShrink)
		do: [:each | self class removeSelector: each]