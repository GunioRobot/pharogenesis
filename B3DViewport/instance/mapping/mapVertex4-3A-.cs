mapVertex4: aVector
	| w x y oneOverW |
	w _ aVector w.
	w = 1.0 ifTrue:[
		x _ aVector x.
		y _ aVector y.
	] ifFalse:[
		w = 0.0
			ifTrue:[oneOverW _ 0.0]
			ifFalse:[oneOverW _ 1.0 / w].
		x _ aVector x * oneOverW.
		y _ aVector y * oneOverW.
	].
	^((x@y) * scale + center) truncated