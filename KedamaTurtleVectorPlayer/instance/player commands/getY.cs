getY

	| yArray |
	exampler getGrouped ifFalse: [
		^ arrays at: 3.
	] ifTrue: [
		yArray _ arrays at: 3.
		yArray size = 0 ifTrue: [^ exampler getY].
		^ yArray first.
	].
