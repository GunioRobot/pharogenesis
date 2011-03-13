makePrototypeOfExampler: examplerPlayer color: cPixel

	| array inst info |
	array _ examplerPlayer turtles.
	info _ array info.
	array size > 0 ifTrue: [
		inst _ array makePrototypeFromFirstInstance.
		cPixel ifNotNil: [inst at: (info at: #color) put: cPixel].
		^ inst.
	].

	inst _ Array new: array instSize.
	info associationsDo: [:assoc |
		inst at: (assoc value) put: (examplerPlayer perform: (Utilities getterSelectorFor: assoc key)).
	].
	cPixel ifNotNil: [inst at: (info at: #color) put: cPixel] ifNil: [inst at: (info at: #color) put: ((examplerPlayer getColor pixelValueForDepth: 32) bitAnd: 16rFFFFFF)].
	inst at: (info at: #visible) put: ((inst at: (info at: #visible)) ifTrue: [1] ifFalse: [0]).
	^ inst.
