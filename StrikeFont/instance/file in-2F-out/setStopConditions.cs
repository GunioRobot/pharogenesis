setStopConditions
	"This has to do with scanning characters, not with the font"
	stopConditions _ Array new: 258.
	stopConditions atAllPut: nil.
	1 to: (minAscii - 1) do:
		[:index | stopConditions at: index put: #characterNotInFont].
	(maxAscii + 3) to: stopConditions size do:
		[:index | stopConditions at: index put: #characterNotInFont].
	self reset