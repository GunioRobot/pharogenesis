scanForWordRunFrom: here to: end
	"Returns an array with (starting byte index) , (length of run in 4-byte words)"
	| runStart runLen |
	here + 7 > end ifTrue: [^ Array with: 0 with: 0].  "Need at least 8 bytes"
	"Scan for i such that a(i+j+4) = a(i+j), for j=0...n, n>=7"
	runStart _ here.  runLen _ 0.
	here to: end-4 do:
		[:i | (self byteAt: i) = (self byteAt: i+4)
			ifTrue: [runLen _ runLen + 1]
			ifFalse: [runLen >= 8 ifTrue: [^ Array with: runStart with: runLen//4].
					runStart _ i + 1.  runLen _ 0]].
	runLen >= 8 ifTrue: [^ Array with: runStart with: runLen//4].
	^ Array with: 0 with: 0