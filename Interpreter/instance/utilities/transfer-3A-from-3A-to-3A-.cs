transfer: count from: src to: dst 
	| in out lastIn |
	self inline: true.
	in _ src - 4.
	lastIn _ in + (count * 4).
	out _ dst - 4.
	[in < lastIn]
		whileTrue: [self
				longAt: (out _ out + 4)
				put: (self longAt: (in _ in + 4))]