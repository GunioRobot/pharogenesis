characterFormAt: character put: characterForm 

	| ascii leftX rightX widthDif newGlyphs encoding xTable glyphs |
	encoding _ character leadingChar + 1.
	ascii _ character charCode.
	ascii < (fontArray at: encoding) minAscii ifTrue: [
		^ self error: 'Cant store characters below min ascii'
	].
	ascii > (fontArray at: encoding) maxAscii ifTrue: [
		^ self error: 'No change made'
	].
	xTable _ (fontArray at: encoding) xTable.
	leftX _ xTable at: ascii + 1.
	rightX _ xTable at: ascii + 2.
	glyphs _ (fontArray at: encoding) glyphs.
	widthDif _ characterForm width - (rightX - leftX).
	widthDif ~= 0 ifTrue: [
		newGlyphs _ Form extent: glyphs width + widthDif @ glyphs height.
		newGlyphs copy: (0 @ 0 corner: leftX @ glyphs height) from: 0 @ 0
			in: glyphs rule: Form over.
		newGlyphs
				copy: (rightX + widthDif @ 0 corner: newGlyphs width @ glyphs height)
				from: rightX @ 0 in: glyphs rule: Form over.
		glyphs _ newGlyphs.
		"adjust further entries on xTable"
		xTable _ xTable copy.
		ascii + 2 to: xTable size do: [:i |
			xTable at: i put: (xTable at: i) + widthDif]].
	glyphs copy: (leftX @ 0 extent: characterForm extent) from: 0 @ 0 in: characterForm rule: Form over.
