scanForNoRunOf: minLen from: here to: end
	| val runLen runStart |
	(here + minLen - 1) > end ifTrue: [^ end - here + 1].
	runStart _ here.  val _ self byteAt: runStart.
	here + 1 to: end do:
		[:i | (self byteAt: i) = val
			ifTrue: [runLen _ i - runStart + 1.
					runLen >= minLen ifTrue: [^ runStart - here]]
			ifFalse: [runStart _ i.  val _ self byteAt: runStart]].
	^ end - here + 1