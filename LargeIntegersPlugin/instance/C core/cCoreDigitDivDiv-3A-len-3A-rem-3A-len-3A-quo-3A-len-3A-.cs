cCoreDigitDivDiv: pDiv len: divLen rem: pRem len: remLen quo: pQuo len: quoLen 
	| dl ql dh dnh j t hi lo r3 l a cond q r1r2 mul |
	self var: #pDiv declareC: 'unsigned char * pDiv'.
	self var: #pRem declareC: 'unsigned char * pRem'.
	self var: #pQuo declareC: 'unsigned char * pQuo'.
	dl _ divLen - 1.
	"Last actual byte of data (ST ix)"
	ql _ quoLen.
	dh _ pDiv at: dl - 1.
	dl = 1
		ifTrue: [dnh _ 0]
		ifFalse: [dnh _ pDiv at: dl - 2].
	1 to: ql do: 
		[:k | 
		"maintain quo*arg+rem=self"
		"Estimate rem/div by dividing the leading two bytes of rem by dh."
		"The estimate is q = qhi*16+qlo, where qhi and qlo are nibbles."
		"Nibbles are kicked off! We use full 16 bits now, because we are in  
		the year 2000 ;-) [sr]"
		j _ remLen + 1 - k.
		"r1 _ rem digitAt: j."
		(pRem at: j - 1)
			= dh
			ifTrue: [q _ 255]
			ifFalse: 
				["Compute q = (r1,r2)//dh, t = (r1,r2)\\dh.                
				Note that r1,r2 are bytes, not nibbles.                
				Be careful not to generate intermediate results exceeding 13  
				            bits."
				"r2 _ (rem digitAt: j - 2)."
				r1r2 _ ((pRem at: j - 1)
							bitShift: 8)
							+ (pRem at: j - 2).
				t _ r1r2 \\ dh.
				q _ r1r2 // dh.
				"Next compute (hi,lo) _ q*dnh"
				mul _ q * dnh.
				hi _ mul bitShift: -8.
				lo _ mul bitAnd: 255.
				"Correct overestimate of q.                
				Max of 2 iterations through loop -- see Knuth vol. 2"
				j < 3
					ifTrue: [r3 _ 0]
					ifFalse: [r3 _ pRem at: j - 3].
				
				[(t < hi
					or: [t = hi and: [r3 < lo]])
					ifTrue: 
						["i.e. (t,r3) < (hi,lo)"
						q _ q - 1.
						lo _ lo - dnh.
						lo < 0
							ifTrue: 
								[hi _ hi - 1.
								lo _ lo + 256].
						cond _ hi >= dh]
					ifFalse: [cond _ false].
				cond]
					whileTrue: [hi _ hi - dh]].
		"Subtract q*div from rem"
		l _ j - dl.
		a _ 0.
		1 to: divLen do: 
			[:i | 
			hi _ (pDiv at: i - 1)
						* (q bitShift: -8).
			lo _ a + (pRem at: l - 1) - ((pDiv at: i - 1)
							* (q bitAnd: 255)).
			"pRem at: l - 1 put: lo - (lo // 256 * 256)."
			"sign-tolerant form of (lo bitAnd: 255) -> obsolete..."
			pRem at: l - 1 put: (lo bitAnd: 255).
			"... is sign-tolerant! [sr]"
			a _ lo // 256 - hi.
			l _ l + 1].
		a < 0
			ifTrue: 
				["Add div back into rem, decrease q by 1"
				q _ q - 1.
				l _ j - dl.
				a _ 0.
				1 to: divLen do: 
					[:i | 
					a _ (a bitShift: -8)
								+ (pRem at: l - 1) + (pDiv at: i - 1).
					pRem at: l - 1 put: (a bitAnd: 255).
					l _ l + 1]].
		pQuo at: quoLen - k put: q]