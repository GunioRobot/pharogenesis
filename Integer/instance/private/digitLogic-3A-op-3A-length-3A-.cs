digitLogic: arg op: op length: len
	| result neg1 neg2 rneg z1 z2 rz b1 b2 b |
	neg1 _ self negative.
	neg2 _ arg negative.
	rneg _ 
		((neg1 ifTrue: [-1] ifFalse: [0])
			perform: op 
			with: (neg2
					ifTrue: [-1]
					ifFalse: [0])) < 0.
	result _ Integer new: len neg: rneg.
	rz _ z1 _ z2 _ true.
	1 to: result digitLength do: 
		[:i | 
		b1 _ self digitAt: i.
		neg1 
			ifTrue: [b1 _ z1
						ifTrue: [b1 = 0
									ifTrue: [0]
									ifFalse: 
										[z1 _ false.
										256 - b1]]
						ifFalse: [255 - b1]].
		b2 _ arg digitAt: i.
		neg2 
			ifTrue: [b2 _ z2
						ifTrue: [b2 = 0
									ifTrue: [0]
									ifFalse: 
										[z2 _ false.
										256 - b2]]
						ifFalse: [255 - b2]].
		b _ b1 perform: op with: b2.
		result 
			digitAt: i 
			put: (rneg
					ifTrue: [rz ifTrue: [b = 0
										ifTrue: [0]
										ifFalse:
											[rz _ false.
											256 - b]]
								ifFalse: [255 - b]]
				ifFalse: [b])].
	^ result normalize