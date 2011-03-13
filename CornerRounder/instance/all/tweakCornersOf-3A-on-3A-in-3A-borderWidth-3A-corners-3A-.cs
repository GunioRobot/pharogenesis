tweakCornersOf: aMorph on: aCanvas in: bounds borderWidth: w corners: cornerList
	"This variant has a cornerList argument, to allow some corners to be rounded and others not"
	| offset corner saveBits fourColors mask outBits shadowColor corners |
	shadowColor := aCanvas shadowColor.
	aCanvas shadowColor: nil. "for tweaking it's essential"
	w > 0 ifTrue:[
			fourColors := shadowColor 
				ifNil:[aMorph borderStyle colorsAtCorners]
				ifNotNil:[Array new: 4 withAll: Color transparent]].
	mask := Form extent: cornerMasks first extent depth: aCanvas depth.
	corners := bounds corners.
	cornerList do:[:i|
		corner := corners at: i.
		saveBits := underBits at: i.
		saveBits ifNotNil:[
			i = 1 ifTrue: [offset := 0@0].
			i = 2 ifTrue: [offset := 0@saveBits height negated].
			i = 3 ifTrue: [offset := saveBits extent negated].
			i = 4 ifTrue: [offset := saveBits width negated@0].

			"Mask out corner area (painting saveBits won't clear if transparent)."
			mask copyBits: mask boundingBox from: (cornerMasks at: i) at: 0@0 clippingBox: mask boundingBox rule: Form over fillColor: nil map: (Bitmap with: 0 with: 16rFFFFFFFF).
			outBits := aCanvas contentsOfArea: (corner + offset extent: mask extent).
			mask displayOn: outBits at: 0@0 rule: Form and.
			"Paint back corner bits."
			saveBits displayOn: outBits at: 0@0 rule: Form paint.
			"Paint back corner bits."
			aCanvas drawImage: outBits at: corner + offset.

			w > 0 ifTrue:[
				
				aCanvas stencil: (cornerOverlays at: i) at: corner + offset
						color: (fourColors at: i)]]].
	aCanvas shadowColor: shadowColor. "restore shadow color"
