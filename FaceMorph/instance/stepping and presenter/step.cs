step
	| amount |
	super step.
	10 atRandom = 1
		ifTrue: [[self lips perform: #(smile horror surprise sad grin) atRandom.
				 (Delay forMilliseconds: 2000 atRandom) wait.
				 self lips perform: #(neutral neutral smile sad) atRandom] fork].
	5 atRandom = 1
		ifTrue: [[self closeEyelids.
				 (Delay forMilliseconds: 180) wait.
				 self openEyelids.
				 2 atRandom = 1 ifTrue: [self lookAtFront]] fork.
				^ self].
	"20 atRandom = 1 ifTrue: [(self perform: #(leftEye rightEye) atRandom) closeEyelid]."
	20 atRandom = 1 ifTrue: [amount := (0.2 to: 1.0 by: 0.01) atRandom.
							 self leftEye openness: amount. self rightEye openness: amount].
	3 atRandom = 1 ifTrue: [self lookAtHand. ^ self].
	3 atRandom = 1 ifTrue: [self lookAtFront. ^ self].
	3 atRandom = 1 ifTrue: [self lookAtMorph: self world submorphs atRandom]