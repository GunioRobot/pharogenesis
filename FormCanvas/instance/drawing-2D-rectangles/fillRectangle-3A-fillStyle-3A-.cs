fillRectangle: aRectangle fillStyle: aFillStyle
	"Fill the given rectangle."
	| pattern |
	self shadowColor ifNotNil:
		[^self fillRectangle: aRectangle color: self shadowColor].

	(aFillStyle isBitmapFill and:[aFillStyle isKindOf: InfiniteForm]) ifTrue:[
		self flag: #fixThis.
		^self fillRectangle: aRectangle color: aFillStyle].

	(aFillStyle isSolidFill) 
		ifTrue:[^self fillRectangle: aRectangle color: aFillStyle asColor].
	"We have a very special case for filling with infinite forms"
	(aFillStyle isBitmapFill and:[aFillStyle origin = (0@0)]) ifTrue:[
		pattern _ aFillStyle form.
		(aFillStyle direction = (pattern width @ 0) 
			and:[aFillStyle normal = (0@pattern height)]) ifTrue:[
				"Can use an InfiniteForm"
				^self fillRectangle: aRectangle color: (InfiniteForm with: pattern)].
	].
	"Use a BalloonCanvas instead"
	self asBalloonCanvas fillRectangle: aRectangle fillStyle: aFillStyle.