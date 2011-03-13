fromStream: aStream named: aName
	| chgRec changes |
	changes := ChangeSet scanFile: aStream from: 0 to: aStream size.
	aStream close.
	('Processing ', aName) 
		displayProgressAt: Sensor cursorPoint
		from: 1
		to: changes size
		during:[:bar|
			1 to: changes size do:[:i|
				bar value: i.
				chgRec := changes at: i.
				self perform: (chgRec type copyWith: $:) asSymbol
with: chgRec.
			].
		].