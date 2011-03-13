fileInFrom: aStream
	| chgRec changes |
	changes := (ChangeList new scanFile: aStream from: 0
to: aStream size) changeList.
	aStream close.
	('Processing ', self packageName) 
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