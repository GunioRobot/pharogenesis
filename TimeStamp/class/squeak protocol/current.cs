current

	| ts ticks |
	ts _ super now.
	
	ticks _ ts ticks.
	ticks at: 3 put: 0.
	ts ticks: ticks offset: ts offset.
	
	^ ts
		
