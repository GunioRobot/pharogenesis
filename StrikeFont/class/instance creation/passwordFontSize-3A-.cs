passwordFontSize: aSize
	| aFont newXTable newGlyphs |
	aFont _ (StrikeFont familyName: #NewYork10 size: aSize) copy.
	newXTable _ aFont xTable copy.
	newGlyphs _ aFont glyphs copy.
	aFont instVarNamed: 'xTable' put: newXTable.
	aFont instVarNamed: 'glyphs' put: newGlyphs.
	aFont minAscii to: aFont maxAscii do: [:ascii |
		aFont characterFormAt: ascii asCharacter put: (aFont characterFormAt: $*)].
	^aFont