testPrintOn: aStream base: base
	"Print me in the given base,"

	| fBase significand exp baseExpEstimate be be1 r s mPlus mMinus scale roundingIncludesLimits d tc1 tc2 |
	self isInf ifTrue: [^ aStream nextPutAll: 'Inf'].
	fBase _ base asFloat.
	significand _ self significandAsInteger.
	roundingIncludesLimits _ significand even.
	exp _ (self exponent - 52) max: MinValLogBase2.
	baseExpEstimate _ (exp + 52 * fBase reciprocalLogBase2 - 1.0e-10) ceiling.
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

	[d _ r // s.
	r _ r \\ s.
	(tc1 _ (r < mMinus) | (roundingIncludesLimits & (r = mMinus))) |
	(tc2 _ (r + mPlus > s) | (roundingIncludesLimits & (r + mPlus = s)))] whileFalse:
		[aStream nextPut: (Character digitValue: d).
		r _ r * base.
		mPlus _ mPlus * base.
		mMinus _ mMinus * base].
	tc2 ifTrue:
		[tc1 not | (tc1 & (r*2 >= s)) ifTrue: [d _ d + 1]].
	aStream nextPut: (Character digitValue: d).
	aStream nextPut: $e.
	aStream nextPutAll: baseExpEstimate printString.