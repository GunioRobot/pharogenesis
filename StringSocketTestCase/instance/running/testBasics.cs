testBasics
	end1 nextPut: #().
	end1 nextPut: #('').
	end1 nextPut: #('hello' 'world').
	end1 processIO.
	
	end2 processIO.

	self should: [ end2 next = #() ].
	self should: [ end2 next = #('') ].
	self should: [ end2 next = #('hello' 'world') ].
	