parseUnicodeDataFrom: stream
"
	self halt.
	self parseUnicodeDataFile
"

	| line fieldEnd point fieldStart toNumber generalCategory decimalProperty |

	toNumber _ [:quad | ('16r', quad) asNumber].

	GeneralCategory _ SparseLargeTable new: 16rE0080 chunkSize: 1024 arrayClass: Array base: 1 defaultValue:  'Cn'.
	DecimalProperty _ SparseLargeTable new: 16rE0080 chunkSize: 32 arrayClass: Array base: 1 defaultValue: -1.

	16r3400 to: 16r4DB5 do: [:i | GeneralCategory at: i+1 put: 'Lo'].
	16r4E00 to: 16r9FA5 do: [:i | GeneralCategory at: i+1 put: 'Lo'].
	16rAC00 to: 16rD7FF do: [:i | GeneralCategory at: i+1 put: 'Lo'].

	[(line _ stream upTo: Character cr) size > 0] whileTrue: [
		fieldEnd _ line indexOf: $; startingAt: 1.
		point _ toNumber value: (line copyFrom: 1 to: fieldEnd - 1).
		point > 16rE007F ifTrue: [
			GeneralCategory zapDefaultOnlyEntries.
			DecimalProperty zapDefaultOnlyEntries.
			^ self].
		2 to: 3 do: [:i |
			fieldStart _ fieldEnd + 1.
			fieldEnd _ line indexOf: $; startingAt: fieldStart.
		].
		generalCategory _ line copyFrom: fieldStart to: fieldEnd - 1.
		GeneralCategory at: point+1 put: generalCategory.
		generalCategory = 'Nd' ifTrue: [
			4 to: 7 do: [:i |
				fieldStart _ fieldEnd + 1.
				fieldEnd _ line indexOf: $; startingAt: fieldStart.
			].
			decimalProperty _  line copyFrom: fieldStart to: fieldEnd - 1.
			DecimalProperty at: point+1 put: decimalProperty asNumber.
		].
	].
	GeneralCategory zapDefaultOnlyEntries.
	DecimalProperty zapDefaultOnlyEntries.
