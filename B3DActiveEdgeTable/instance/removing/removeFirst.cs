removeFirst
	stop _ stop - 1.
	array replaceFrom: start to: stop with: array startingAt: start+1.
	start _ start - 1.
	array at: stop+1 put: nil.