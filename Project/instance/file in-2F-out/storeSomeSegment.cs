storeSomeSegment
	"Try all projects to see if any is ready to go out.  Send at most three of them.
	Previous one has to wait for a garbage collection before it can go out."

	| cnt pList start proj gain |
	cnt _ 0.  gain _ 0.
	pList _ Project allProjects.
	start _ pList size atRandom.	"start in a random place"
	start to: pList size + start do: [:ii | 
		proj _ pList atWrap: ii.
		proj storeSegment ifTrue: ["Yes, did send its morphs to the disk"
			gain _ gain + (proj projectParameters at: #segmentSize 
						ifAbsent: [0]).	"a guess"
			self beep.
			(cnt _ cnt + 1) >= 2 ifTrue: [^ gain]]].
	self beep.
	^ gain