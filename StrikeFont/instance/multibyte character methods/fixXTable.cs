fixXTable

	| newXTable val |
	xTable size >= 258 ifTrue: [
		^ self.
	].

	newXTable _ Array new: 258.
	1 to: xTable size do: [:i |
		newXTable at: i put: (xTable at: i).
	].

	val _ xTable at: (xTable size).
	
	xTable size + 1 to: 258 do: [:i |
		newXTable at: i put: val.
	].
	minAscii _ 0.
	maxAscii _ 255.
	xTable _ newXTable.
