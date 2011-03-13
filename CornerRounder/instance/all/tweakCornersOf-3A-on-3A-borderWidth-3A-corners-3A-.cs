tweakCornersOf: aMorph on: aCanvas borderWidth: w corners: cornerList
	"This variant has a cornerList argument, to allow some corners to be rounded and others not"
	| offset corner saveBits c fourColors c14 c23 insetColor mask outBits shadowColor |
	shadowColor _ aCanvas shadowColor.
	aCanvas shadowColor: nil. "for tweaking it's essential"
	w > 0 ifTrue:
		[c _ shadowColor ifNil:[aMorph borderColor].
		fourColors _ Array new: 4 withAll: c.
		c == #raised ifTrue:
			[c14 _ aMorph color lighter. c23 _ aMorph color darker.
			fourColors _ Array with: c14 with: c23 with: c23 with: c14].
		(c == #inset and: [aMorph owner notNil]) ifTrue:
			[insetColor _ aMorph owner colorForInsets.
			c14 _ insetColor lighter. c23 _ insetColor darker.
			fourColors _ Array with: c14 with: c23 with: c23 with: c14]].
	mask _ Form extent: cornerMasks first extent depth: aCanvas depth.
	1 to: 4 do:[:i | 
		(cornerList includes: i) ifTrue:
			[corner _ aMorph bounds corners at: i.
			saveBits _ underBits at: i.
			i = 1 ifTrue: [offset _ 0@0].
			i = 2 ifTrue: [offset _ 0@saveBits height negated].
			i = 3 ifTrue: [offset _ saveBits extent negated].
			i = 4 ifTrue: [offset _ saveBits width negated@0].

			"Mask out corner area (painting saveBits won't clear if transparent)."
			mask copyBits: mask boundingBox from: (cornerMasks at: i) at: 0@0 clippingBox: mask boundingBox rule: Form over fillColor: nil map: (Bitmap with: 0 with: 16rFFFFFFFF).
			outBits _ aCanvas contentsOfArea: (corner + offset extent: mask extent).
			mask displayOn: outBits at: 0@0 rule: Form and.
			"Paint back corner bits."
			saveBits displayOn: outBits at: 0@0 rule: Form paint.
			"Paint back corner bits."
			aCanvas drawImage: outBits at: corner + offset.

			w > 0 ifTrue:
				["Paint over with border if any"
				aCanvas stencil: (cornerOverlays at: i) at: corner + offset
						color: (fourColors at: i)]]].
	aCanvas shadowColor: shadowColor. "restore shadow color"
