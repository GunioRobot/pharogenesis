quo: aNumber 
	"Refer to the comment in Number quo: "
	| ng quo |
	aNumber isInteger ifTrue: 
		[ng _ self negative == aNumber negative == false.
		quo _ (self digitDiv:
			(aNumber class == SmallInteger
				ifTrue: [aNumber abs]
				ifFalse: [aNumber])
			neg: ng) at: 1.
		^ quo normalize].
	^ aNumber adaptToInteger: self andSend: #quo: