scanForRunOf: minLen from: here to: end
	| val runLen |
	(here + minLen - 1) > end ifTrue: [^ 0].
	val _ self byteAt: here.
	here + 1 to: end do:
		[:i | (self byteAt: i) = val ifFalse:
			[runLen _ i - here.
			runLen < minLen ifTrue: [^ 0] ifFalse: [^ runLen]]].
	^ end - here + 1