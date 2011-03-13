discardDiscards
	"Discard all discard* methods - including this one."

	(self class selectors select: [:each | each beginsWith: 'discard']) 
		do: [:each | self class removeSelector: each].
	#(lastRemoval majorShrink zapMVCprojects)
		do: [:each | self class removeSelector: each]