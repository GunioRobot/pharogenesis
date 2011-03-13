fadeImageCoarse: otherImage at: topLeft
	"Display fadeImageCoarse: (Form fromDisplay: (40@40 extent: 300@300)) reverse at: 40@40"
	| pix j |
	^ self fadeImage: otherImage at: topLeft indexAndMaskDo:
		[:i :mask |
		i=1 ifTrue: [pix _ (1 bitShift: depth) - 1.
					1 to: 8//depth-1 do: [:q | pix _ pix bitOr: (pix bitShift: depth*4)]].
		i <= 16 ifTrue:
		[j _ i-1//4+1.
		(0 to: 28 by: 4) do: [:k |
			mask bits at: j+k
				put: ((mask bits at: j+k) bitOr: (pix bitShift: i-1\\4*depth))].
		"mask display." true]
		ifFalse: [false]]