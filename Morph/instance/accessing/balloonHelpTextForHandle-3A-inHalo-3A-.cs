balloonHelpTextForHandle: aHandle inHalo: aHalo
	^ 'If you click on the ' , aHandle color name , ' handle,
it will ' , (#('probably not do anything.'
		'let you pick up this object.'
		'let you rotate this object.'
		'bring up a menu for this object.'
		'let you resize this object.'
		'let you duplicate this object.'
		'show information about this object.'
		'let you drag this object'
		'let you change the font'
		'let you change the style'
		'let you change the emphasis'
		'let you look inside this object'
		'repaint this object')
	at: (#(none black blue red yellow green lightBlue brown lightGreen lightRed lightBrown lightYellow lightGray) indexOf: aHandle
color name ifAbsent: [1]))