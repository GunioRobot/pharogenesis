saveBitsUnderCornersOf: aMorph on: aCanvas

	| offset corner mask form |
	underBits _ (1 to: 4) collect:
		[:i | 
		mask _ cornerMasks at: i.
		corner _ aMorph bounds corners at: i.
		i = 1 ifTrue: [offset _ 0@0].
		i = 2 ifTrue: [offset _ 0@mask height negated].
		i = 3 ifTrue: [offset _ mask extent negated].
		i = 4 ifTrue: [offset _ mask width negated@0].
		form _ aCanvas contentsOfArea: (corner + offset extent: mask extent).
		form copyBits: form boundingBox from: mask at: 0@0 clippingBox: form boundingBox rule: Form and fillColor: nil map: (Bitmap with: 16rFFFFFFFF with: 0)].
