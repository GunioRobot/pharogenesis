saveBitsUnderCornersOf: aMorph on: aCanvas in: bounds corners: cornerList

	| offset corner mask form corners rect |
	underBits _ Array new: 4.
	corners _ bounds corners.
	cornerList do:[:i|
		mask _ cornerMasks at: i.
		corner _ corners at: i.
		i = 1 ifTrue: [offset _ 0@0].
		i = 2 ifTrue: [offset _ 0@mask height negated].
		i = 3 ifTrue: [offset _ mask extent negated].
		i = 4 ifTrue: [offset _ mask width negated@0].
		rect _ corner + offset extent: mask extent.
		(aCanvas isVisible: rect) ifTrue:[
			form _ aCanvas contentsOfArea: rect.
			form copyBits: form boundingBox from: mask at: 0@0 clippingBox: form boundingBox rule: Form and fillColor: nil map: (Bitmap with: 16rFFFFFFFF with: 0).
			underBits at: i put: form]].
