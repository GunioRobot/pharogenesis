addSquares
	| white black square index |
	white _ Color white.
	black _ Color lightGray.
	index _ 0.
	#(
		(	' '	'a'	'b'	'c'	'd'	'e'	'f'	'g'	'h'	' ')
		(	'1'	'B'	'W'	'B'	'W'	'B'	'W'	'B'	'W'	' ')
		(	'2'	'W'	'B'	'W'	'B'	'W'	'B'	'W'	'B'	' ')
		(	'3'	'B'	'W'	'B'	'W'	'B'	'W'	'B'	'W'	' ')
		(	'4'	'W'	'B'	'W'	'B'	'W'	'B'	'W'	'B'	' ')
		(	'5'	'B'	'W'	'B'	'W'	'B'	'W'	'B'	'W'	' ')
		(	'6'	'W'	'B'	'W'	'B'	'W'	'B'	'W'	'B'	' ')
		(	'7'	'B'	'W'	'B'	'W'	'B'	'W'	'B'	'W'	' ')
		(	'8'	'W'	'B'	'W'	'B'	'W'	'B'	'W'	'B'	' ')
		(	' '	' '	' '	' '	' '	' '	' '	' '	' '	' ')
	) do:[:file|
		file do:[:sq|
		square _ self newSquare.
		square borderWidth: 0.
		(sq = 'W' or:[sq = 'B']) ifTrue:[
			square color: (sq = 'W' ifTrue:[white] ifFalse:[black]).
			square borderColor: Color red.
			square setProperty: #squarePosition toValue: (index _ index + 1).
			square setNameTo: 
				(String with: ($a asInteger + (index - 1 bitAnd: 7)) asCharacter with: ($1 asInteger + (index -1 bitShift: -3)) asCharacter).
			square on: #mouseEnter send: #showMoves:from: to: self.
			square on: #mouseEnterDragging send: #dragSquareEnter:from: to: self.
			square on: #mouseLeaveDragging send: #dragSquareLeave:from: to: self.
		] ifFalse:["decoration"
			square color: Color transparent.
			sq = ' ' ifFalse:[
				square addMorphCentered: (StringMorph contents: sq asUppercase font: Preferences windowTitleFont emphasis: 1).
			].
		].
		square extent: 40@40.
		self addMorphBack: square.
	]].
