stats
	| oop fieldAddr fieldOop last ints ints100 ints1000 fields ints10 spl v intsM100 intsM1000 rel100 rel1000 relM100 relM1000 d |
	Transcript show: 'Taking stats...'.
	ints _ fields _ 0.
	ints10 _ ints100 _ ints1000 _ intsM100 _ intsM1000 _ 0.
	rel100 _ rel1000 _ relM100 _ relM1000 _ 0.
	spl _ Bag new.
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue:
		[(self isFreeObject: oop) ifFalse:
			[fieldAddr _ oop + (self lastPointerOf: oop).
			[fieldAddr > oop] whileTrue:
				[fieldOop _ self longAt: fieldAddr.
				fields _ fields + 1.
				(self isIntegerObject: fieldOop)
					ifTrue: [v _ self integerValueOf: fieldOop.
							ints _ ints + 1.
							(v between: 0 and: 10) ifTrue: [ints10 _ ints10 + 1].
							(v between: 0 and: 100) ifTrue: [ints100 _ ints100 + 1].
							(v between: 0 and: 1000) ifTrue: [ints1000 _ ints1000 + 1].
							(v between: -100 and: -1) ifTrue: [intsM100 _ intsM100 + 1].
							(v between: -1000 and: -1) ifTrue: [intsM1000 _ intsM1000 + 1]]
					ifFalse: [fieldOop = nilObj ifTrue: [spl add: fieldOop].
							fieldOop = falseObj ifTrue: [spl add: fieldOop].
							fieldOop = trueObj ifTrue: [spl add: fieldOop].
							d _ fieldOop - oop.
							(d between: 0 and: 100) ifTrue: [rel100 _ rel100 + 1].
							(d between: 0 and: 1000) ifTrue: [rel1000 _ rel1000 + 1].
							(d between: -100 and: -1) ifTrue: [relM100 _ relM100 + 1].
							(d between: -1000 and: -1) ifTrue: [relM1000 _ relM1000 + 1]].
				fieldAddr _ fieldAddr - 4]].
		last _ oop.
		oop _ self objectAfter: oop].
	Transcript show: 'done.'; cr.
	^ (Array with: fields with: ints with: ints10) ,
		(Array with: ints100 with: ints1000 with: intsM100 with: intsM1000) ,
		(Array with: rel100 with: rel1000 with: relM100 with: relM1000) ,
		(Array with: spl sortedElements)
