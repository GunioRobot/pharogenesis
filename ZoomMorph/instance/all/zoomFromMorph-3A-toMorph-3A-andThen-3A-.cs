zoomFromMorph: m1 toMorph: m2 andThen: actionBlock
	| nSteps topLeft r2 r1 extent ratio r mouthDeltas |
	fromMorph _ m1.
	toMorph _ m2.
	r1 _ fromMorph fullBounds.
	r2 _ toMorph fullBounds.
	finalAction _ actionBlock.
	nSteps _ 8.
	boundsSeq _ OrderedCollection new.
	r _ (1/nSteps) asFloat.
	ratio _ r.
r1 _ 105@326 corner: 130@348.
mouthDeltas _ {-7@24. -6@21. -6@18. -4@14. -4@10. -3@8. -3@3. 0@0}.
	1 to: nSteps do:
		[:i | topLeft _ ((r2 topLeft - r1 topLeft) * ratio) asIntegerPoint + r1 topLeft.
		extent _ ((r2 extent - r1 extent) * ratio) asIntegerPoint + r1 extent.
		boundsSeq addLast: (topLeft + (mouthDeltas at: i) extent: extent).
		ratio _ ratio + r].
	self addMorph: toMorph.
	self step