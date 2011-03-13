absPrintExactlyOn: aStream base: base
	"Print my value on a stream in the given base.  Assumes that my value is strictly
	positive; negative numbers, zero, and NaNs have already been handled elsewhere.
	Based upon the algorithm outlined in:
	Robert G. Burger and R. Kent Dybvig
	Printing Floating Point Numbers Quickly and Accurately
	ACM SIGPLAN 1996 Conference on Programming Language Design and Implementation
	June 1996.
	This version guarantees that the printed representation exactly represents my value
	by using exact integer arithmetic."

	| fBase significand exp baseExpEstimate be be1 r s mPlus mMinus scale roundingIncludesLimits d tc1 tc2 fixedFormat decPointCount |
	self isInfinite ifTrue: [aStream nextPutAll: 'Infinity'. ^ self].
	fBase _ base asFloat.
	significand _ self significandAsInteger.
	roundingIncludesLimits _ significand even.
	exp _ (self exponent - 52) max: MinValLogBase2.
	baseExpEstimate _ (self exponent * fBase reciprocalLogBase2 - 1.0e-10) ceiling.
	exp >= 0
		ifTrue:
			[be _ 1 << exp.
			significand ~= 16r10000000000000
				ifTrue:
					[r _ significand * be * 2.
					s _ 2.
					mPlus _ be.
					mMinus _ be]
				ifFalse:
					[be1 _ be * 2.
					r _ significand * be1 * 2.
					s _ 4.
					mPlus _ be1.
					mMinus _ be]]
		ifFalse:
			[(exp = MinValLogBase2) | (significand ~= 16r10000000000000)
				ifTrue:
					[r _ significand * 2.
					s _ (1 << (exp negated)) * 2.
					mPlus _ 1.
					mMinus _ 1]
				ifFalse:
					[r _ significand * 4.
					s _ (1 << (exp negated + 1)) * 2.
					mPlus _ 2.
					mMinus _ 1]].
	baseExpEstimate >= 0
		ifTrue: [s _ s * (base raisedToInteger: baseExpEstimate)]
		ifFalse:
			[scale _ base raisedToInteger: baseExpEstimate negated.
			r _ r * scale.
			mPlus _ mPlus * scale.
			mMinus _ mMinus * scale].
	(r + mPlus > s) | (roundingIncludesLimits & (r + mPlus = s))
		ifTrue: [baseExpEstimate _ baseExpEstimate + 1]
		ifFalse:
			[r _ r * base.
			mPlus _ mPlus * base.
			mMinus _ mMinus * base].
	(fixedFormat _ baseExpEstimate between: -3 and: 6)
		ifTrue:
			[decPointCount _ baseExpEstimate.
			baseExpEstimate <= 0
				ifTrue: [aStream nextPutAll: ('0.000000' truncateTo: 2 - baseExpEstimate)]]
		ifFalse:
			[decPointCount _ 1]. 
	[d _ r // s.
	r _ r \\ s.
	(tc1 _ (r < mMinus) | (roundingIncludesLimits & (r = mMinus))) |
	(tc2 _ (r + mPlus > s) | (roundingIncludesLimits & (r + mPlus = s)))] whileFalse:
		[aStream nextPut: (Character digitValue: d).
		r _ r * base.
		mPlus _ mPlus * base.
		mMinus _ mMinus * base.
		decPointCount _ decPointCount - 1.
		decPointCount = 0 ifTrue: [aStream nextPut: $.]].
	tc2 ifTrue:
		[tc1 not | (tc1 & (r*2 >= s)) ifTrue: [d _ d + 1]].
	aStream nextPut: (Character digitValue: d).
	decPointCount > 0
		ifTrue:
		[decPointCount - 1 to: 1 by: -1 do: [:i | aStream nextPut: $0].
		aStream nextPutAll: '.0'].
	fixedFormat ifFalse:
		[aStream nextPut: $e.
		aStream nextPutAll: (baseExpEstimate - 1) printString]