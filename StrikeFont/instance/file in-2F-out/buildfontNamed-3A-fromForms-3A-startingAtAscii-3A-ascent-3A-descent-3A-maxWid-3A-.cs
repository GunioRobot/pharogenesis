buildfontNamed: nm fromForms: forms startingAtAscii: startAscii
	ascent: a descent: d maxWid: m
	"This builds a StrikeFont instance from existing forms."

	| lastAscii width ascii charForm missingForm tempGlyphs |
	name _ nm.
	ascent _ 11.
	descent _ 3.
	maxWidth _ 16.
	pointSize _ 8.
	name _ (name copyWithout: Character space) ,
				(pointSize < 10
					ifTrue: ['0' , pointSize printString]
					ifFalse: [pointSize printString]).
	minAscii _ 258.
	maxAscii _ 0.
	superscript _ ascent - descent // 3.	
	subscript _ descent - ascent // 3.	
	emphasis _ 0.
	type _ 0.  "ignored for now"

	tempGlyphs _ Form extent: (maxWidth*257) @ self height.
	xTable _ (Array new: 258) atAllPut: 0.
	xTable at: 1 put: 0.

	"Read character forms and blt into tempGlyphs"
	lastAscii _ -1.
	1 to: forms size do:
		[:i | charForm _ forms at: i. width _ charForm width.
		ascii _ startAscii-1+i.
		self displayChar: ascii form: charForm.
		ascii = 256
			ifTrue: [missingForm _ charForm deepCopy]
			ifFalse:
			[minAscii _ minAscii min: ascii.
			maxAscii _ maxAscii max: ascii.
			lastAscii+1 to: ascii-1 do: [:as | xTable at: as+2 put: (xTable at: as+1)].
			tempGlyphs copy: ((xTable at: ascii+1)@0
									extent: charForm extent)
						from: 0@0 in: charForm rule: Form over.
			xTable at: ascii+2 put: (xTable at: ascii+1) + width.
			lastAscii _ ascii]].
	lastAscii+1 to: maxAscii+1 do: [:as | xTable at: as+2 put: (xTable at: as+1)].
	missingForm == nil ifFalse:
		[tempGlyphs copy: missingForm boundingBox from: missingForm
				to: (xTable at: maxAscii+2)@0 rule: Form over.
		xTable at: maxAscii+3 put: (xTable at: maxAscii+2) + missingForm width].
	glyphs _ Form extent: (xTable at: maxAscii+3) @ self height.
	glyphs copy: glyphs boundingBox from: 0@0 in: tempGlyphs rule: Form over.
	xTable _ xTable copyFrom: 1 to: maxAscii+3.
	characterToGlyphMap _ nil.