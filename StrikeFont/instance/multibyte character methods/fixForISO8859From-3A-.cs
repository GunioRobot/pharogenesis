fixForISO8859From: aStrikeFont

	| fixer m mappingTable |
	fixer _ StrikeFontFixer newOn: aStrikeFont.
	self reset.
	xTable _ aStrikeFont xTable copy.
	glyphs _ Form extent: aStrikeFont glyphs extent.
	maxAscii _ 255.
	minAscii _ 0.
	mappingTable _ fixer mappingTable.
	"stopConditions _ nil."

	0 to: 255 do: [:i |
		(m _ mappingTable at: i+1) ~= nil ifTrue: [
			self characterFormAt: (Character value: i)
				put: (aStrikeFont characterFormAt: (Character value: m)).
		] ifFalse: [
			self characterFormAt: (Character value: i)
				put: (aStrikeFont characterFormAt: (Character space)).
		]
	].
	^self.	
