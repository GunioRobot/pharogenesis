tweakCornersOf: aMorph on: aCanvas borderWidth: w

	| offset corner saveBits c fourColors c14 c23 mask nonShadowCanvas outBits |
	nonShadowCanvas _ aCanvas copy shadowColor: nil.
	w > 0 ifTrue:
		[c _ aMorph borderColor.
		fourColors _ Array new: 4 withAll: c.
		c == #raised ifTrue:
			[c _ aMorph color.
			w = 1
				ifTrue: [c14 _ c twiceLighter. c23 _ c twiceDarker]
				ifFalse: [c14 _ c lighter. c23 _ c darker].
			fourColors _ Array with: c14 with: c with: c23 with: c].
		(c == #inset and: [aMorph owner notNil]) ifTrue:
			[c _ aMorph owner colorForInsets.
			w = 1
				ifTrue: [c14 _ c twiceLighter. c23 _ c twiceDarker]
				ifFalse: [c14 _ c lighter. c23 _ c darker].
			fourColors _ Array with: c23 with: c with: c14 with: c]].
	mask _ Form extent: cornerMasks first extent depth: aCanvas depth.
	(1 to: 4) do:
		[:i | 
		corner _ aMorph bounds corners at: i.
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
		nonShadowCanvas drawImage: outBits at: corner + offset.

		w > 0 ifTrue:
			["Paint over with border if any"
			aCanvas stencil: (cornerOverlays at: i) at: corner + offset
					color: (fourColors at: i)]].

