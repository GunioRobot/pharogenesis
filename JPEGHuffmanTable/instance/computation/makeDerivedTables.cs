makeDerivedTables

	| huffSize huffCode code si index lookbits |
	mincode _ Array new: 16.
	maxcode _ Array new: 17.
	valptr _ Array new: 17.
	huffSize _ OrderedCollection new.
	1 to: 16 do: [:l | 1 to: (bits at: l) do: [:i | huffSize add: l]].
	huffSize add: 0.
	code _ 0.
	huffCode _ Array new: huffSize size.
	si _ huffSize at: 1.
	index _ 1.
	[(huffSize at: index) ~= 0] whileTrue:
		[[(huffSize at: index) = si] whileTrue:
			[huffCode at: index put: code.
			index _ index + 1.
			code _ code + 1].
		code _ code << 1.
		si _ si + 1].

	index _ 1.
	1 to: 16 do:
		[:l |
		(bits at: l) ~= 0
			ifTrue:
				[valptr at: l put: index.
				mincode at: l put: (huffCode at: index).
				index _ index + (bits at: l).
				maxcode at: l put: (huffCode at: index-1)]
			ifFalse:
				[maxcode at: l put: -1]].
	maxcode at: 17 put: 16rFFFFF.

	lookaheadBits _ (Array new: 1 << Lookahead) atAllPut: 0.
	lookaheadSymbol _ Array new: 1 << Lookahead.
	index _ 1.
	1 to: Lookahead do:
		[:l |
		1 to: (bits at: l) do:
			[:i |
			lookbits _ (huffCode at: index) << (Lookahead - l) + 1.
			(1 << (Lookahead - l) to: 1 by: -1) do:
				[:ctr |
				lookaheadBits at: lookbits put: l.
				lookaheadSymbol at: lookbits put: (values at: index).
				lookbits _ lookbits + 1].
			index _ index + 1]]