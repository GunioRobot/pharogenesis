slowSize
	"Careful! Answer the maximum amount
	of elements in the receiver, not the
	exact amount"

	tally := array inject: 0 into:
		[:total :each | (each == nil or: [each == flag])
			ifTrue: [total] ifFalse: [total + 1]].
	^tally