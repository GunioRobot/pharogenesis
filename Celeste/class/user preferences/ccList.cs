ccList
	"Answer the default cc list to be used in composing messages."

	CCList isNil ifTrue: [CCList _ ''].
	^CCList