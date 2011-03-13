numberOfFieldsOf: index
	| header format size |
	header := segment at: index.
	format := (header >> 8) bitAnd: 16rF.
	format <= 4 ifFalse: [ ^ 0 ].	"no pointer"
		
	(header bitAnd: 3) = 2
		ifTrue: [ ^ 0 ]
		ifFalse: [ size := (header bitAnd: 3) = 0 "HeaderTypeSizeAndClass"
			ifTrue: [ (segment at: index - 2) bitAnd: 16rFFFFFFFC ]
			ifFalse: [ header bitAnd: "SizeMask" 252 ] ].	
	^ size - 4 "header" >> 2 "ShiftForWord"