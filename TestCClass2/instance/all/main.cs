main

	| startTicks ticks |
	self printf: 'atAllPut: '.
	startTicks _ self clock.
	self atAllPut.
	ticks _ self clock - startTicks.
	self print: '%ld\n' f: ticks.

	self printf: 'incrementAll: '.
	self incrementAll.
	ticks _ self clock - startTicks.
	self print: '%ld\n' f: ticks.

	self printf: 'nestedWhileLoop: '.
	self nestedWhileLoop.
	ticks _ self clock - startTicks.
	self print: '%ld\n' f: ticks.

	self printf: 'sieve: '.
	self sieve.
	ticks _ self clock - startTicks.
	self print: '%ld\n' f: ticks.

	self printf: 'sumAll: '.
	self sumAll.
	ticks _ self clock - startTicks.
	self print: '%ld\n' f: ticks.

	self printf: 'sumFromTo: '.
	self sumFromTo.
	ticks _ self clock - startTicks.
	self print: '%ld\n' f: ticks.