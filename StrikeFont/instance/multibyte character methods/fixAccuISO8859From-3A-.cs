fixAccuISO8859From: aStrikeFont

	| f |
	self reset.
	xTable _ aStrikeFont xTable copy.
	glyphs _ Form extent: aStrikeFont glyphs extent.
	maxAscii _ 255.
	minAscii _ 0.
	"stopConditions _ nil."

	0 to: 127 do: [:i |
		f _ aStrikeFont characterFormAt: (Character value: i) isoToSqueak.
		f width  = 0 ifTrue: [f _ Form extent: 1@f height].
		
		self characterFormAt: (Character value: i) put: f.
	].
	128 to: 159 do: [:i |
		f _ Form extent: 1@f height.
		self characterFormAt: (Character value: i) put: f.
	].
	160 to: 255 do: [:i |
		f _ aStrikeFont characterFormAt: (Character value: i) isoToSqueak.
		f width  = 0 ifTrue: [f _ Form extent: 1@f height].
		
		self characterFormAt: (Character value: i) put: f.
	].
		
	^ self.	
