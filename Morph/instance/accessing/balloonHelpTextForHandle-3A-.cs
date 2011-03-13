balloonHelpTextForHandle: aHandle
	| colorName |
	colorName _ aHandle color name.
	#(	(blue					'Rotate')
		(yellow					'Change size') 
		(green					'Make another')
		(black					'Pick up')
		(red						'Menu')
		(lightBlue				'Help')
		(lightBrown				'Make a Tile')
		(lightGray				'Repaint')
		(cyan					'View me')
		(transparent			'Remove')
		(lightGray				'Repaint')
		(lightOrange			'Change scale') 
		(veryVeryLightGray		'Paint new object'))

	do:
		[:pair | colorName == pair first ifTrue: [^ pair last]].

	^ 'If you click on the ' , aHandle color name , ' handle,
it will ' , (#('probably not do anything.'
		'let you change the font'
		'let you change the style'
		'let you change the emphasis')
	at: (#(none  lightGreen lightRed lightBrown ) indexOf: colorName ifAbsent: [1]))