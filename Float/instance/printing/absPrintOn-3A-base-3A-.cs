absPrintOn: aStream base: base
	"Print my value on a stream in the given base.  Assumes that my value is strictly
	positive; negative numbers, zero, and NaNs have already been handled elsewhere.
	Based upon the algorithm outlined in:
	Robert G. Burger and R. Kent Dybvig
	Printing Floating Point Numbers Quickly and Accurately
	ACM SIGPLAN 1996 Conference on Programming Language Design and Implementation
	June 1996.
	This version performs all calculations with Floats instead of LargeIntegers, and loses
	about 3 lsbs of accuracy compared to an exact conversion."

	| significantBits fBase exp baseExpEstimate r s mPlus mMinus scale d tc1 tc2 fixedFormat decPointCount |
	self isInfinite ifTrue: [aStream nextPutAll: 'Infinity'. ^ self].
	significantBits _ 50.  "approximately 3 lsb's of accuracy loss during conversion"
	fBase _ base asFloat.
	exp _ self exponent.
	baseExpEstimate _ (exp * fBase reciprocalLogBase2 - 1.0e-10) ceiling.
	exp >= 0
		ifTrue:
			[r _ self.
			s _ 1.0.
			mPlus _ 1.0 timesTwoPower: exp - significantBits.
			mMinus _ self significand ~= 1.0 ifTrue: [mPlus] ifFalse: [mPlus / 2.0]]
		ifFalse:
			[r _ self timesTwoPower: significantBits.
			s _ 1.0 timesTwoPower:  significantBits.
			mMinus _ 1.0 timesTwoPower: (exp max: -1024).
			mPlus _
				(exp = MinValLogBase2) | (self significand ~= 1.0)
					ifTrue: [mMinus]
					ifFalse: [mMinus * 2.0]].
	baseExpEstimate >= 0
		ifTrue:
			[s _ s * (fBase raisedToInteger: baseExpEstimate).
			exp = 1023
				ifTrue:   "scale down to prevent overflow to Infinity during conversion"
					[r _ r / fBase.
					s _ s / fBase.
					mPlus _ mPlus / fBase.
					mMinus _ mMinus / fBase]]
		ifFalse:
			[exp < -1023
				ifTrue:   "scale up to prevent denorm reciprocals overflowing to Infinity"
					[d _ (53 * fBase reciprocalLogBase2 - 1.0e-10) ceiling.
					scale _ fBase raisedToInteger: d.
					r _ r * scale.
					mPlus _ mPlus * scale.
					mMinus _ mMinus * scale.
					scale _ fBase raisedToInteger: (baseExpEstimate + d) negated]
				ifFalse:
				[scale _ fBase raisedToInteger: baseExpEstimate negated].
			s _ s / scale].
	(r + mPlus >= s)
		ifTrue: [baseExpEstimate _ baseExpEstimate + 1]
		ifFalse:
			[s _ s / fBase].
	(fixedFormat _ baseExpEstimate between: -3 and: 6)
		ifTrue:
			[decPointCount _ baseExpEstimate.
			baseExpEstimate <= 0
				ifTrue: [aStream nextPutAll: ('0.000000' truncateTo: 2 - baseExpEstimate)]]
		ifFalse:
			[decPointCount _ 1].
	[d _ (r / s) truncated.
	r _ r - (d * s).
	(tc1 _ r <= mMinus) | (tc2 _ r + mPlus >= s)] whileFalse:
		[aStream nextPut: (Character digitValue: d).
		r _ r * fBase.
		mPlus _ mPlus * fBase.
		mMinus _ mMinus * fBase.
		decPointCount _ decPointCount - 1.
		decPointCount = 0 ifTrue: [aStream nextPut: $.]].
	tc2 ifTrue:
		[tc1 not | (tc1 & (r*2.0 >= s)) ifTrue: [d _ d + 1]].
	aStream nextPut: (Character digitValue: d).
	decPointCount > 0
		ifTrue:
		[decPointCount - 1 to: 1 by: -1 do: [:i | aStream nextPut: $0].
		aStream nextPutAll: '.0'].
	fixedFormat ifFalse:
		[aStream nextPut: $e.
		aStream nextPutAll: (baseExpEstimate - 1) printString]