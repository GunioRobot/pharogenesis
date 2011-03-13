label: aString
	"Set the receiver's label as indicated"

	| aLabel |
	(aLabel _ self findA: StringMorph)
		ifNotNil:
			[aLabel contents: aString]
		ifNil:
			[aLabel _ StringMorph contents: aString font: TextStyle defaultFont.
			self addMorph: aLabel].

	self extent: aLabel extent + (borderWidth + 6).
	aLabel position: self center - (aLabel extent // 2).

	aLabel lock