collect: aBlock from: firstIndex to: lastIndex
	"Refer to the comment in Collection|collect:."

	| size result j |
	size _ lastIndex - firstIndex + 1.
	result _ self species new: size.
	j _ firstIndex.
	1 to: size do: [:i | result at: i put: (aBlock value: (self at: j)). j _ j + 1].
	^ result