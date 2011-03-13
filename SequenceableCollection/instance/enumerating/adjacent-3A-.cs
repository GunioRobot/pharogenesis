adjacent: aBlock2
	"Evaluate aBlock with adjacent pairs of elements of the receiver. 
	Collect the resulting values into a collection like the receiver.
	Answer the new collection."
	| result |
	self size < 2 ifTrue: [^ self species new].
	result _ self species new: self size-1.
	1 to: self size-1 do:
		[:index | result at: index put:
		(aBlock2 value: (self at: index)
				value: (self at: index+1))].
	^ result