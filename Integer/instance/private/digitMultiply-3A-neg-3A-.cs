digitMultiply: arg neg: ng
	| prod prodLen carry digit k ab |
	(arg digitLength = 1 and: [(arg digitAt: 1) = 0]) ifTrue: [^ 0].
	prodLen _ self digitLength + arg digitLength.
	prod _ Integer new: prodLen neg: ng.
	"prod starts out all zero"
	1 to: self digitLength do: 
		[:i | 
		(digit _ self digitAt: i) ~= 0
			ifTrue: 
				[k _ i.
				carry _ 0.
				"Loop invariant: 0<=carry<=0377, k=i+j-1"
				1 to: arg digitLength do: 
					[:j | 
					ab _ ((arg digitAt: j) * digit) + carry
							+ (prod digitAt: k).
					carry _ ab bitShift: -8.
					prod digitAt: k put: (ab bitAnd: 255).
					k _ k + 1].
				prod digitAt: k put: carry]].
	^ prod normalize