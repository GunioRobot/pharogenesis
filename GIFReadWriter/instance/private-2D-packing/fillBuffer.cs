fillBuffer
	| packSize |
	packSize _ self next.
	bufStream _ ReadStream on: (self next: packSize)