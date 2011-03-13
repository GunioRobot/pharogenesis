filberts: n side: s 
	"Two Hilbert curve fragments form a Hilbert tile. Draw four interlocking 
	tiles of order n and sides length s."
	| n2 |
	Display fillWhite.
	n2 _ 1 bitShift: n - 1.
	self up; go: 0 - n2 * s; down.
	1 to: 4 do: 
		[:i | 
		self color: i - 1 * 40.
		self
			fillInAndFrame: 
				[self hilbert: n side: s.
				self go: s.
				self hilbert: n side: s.
				self go: s].
		self up.
		self go: n2 - 1 * s.
		self turn: -90.
		self go: n2 * s.
		self turn: 180.
		self down]