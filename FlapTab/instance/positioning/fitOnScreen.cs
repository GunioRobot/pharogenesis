fitOnScreen
	| constrainer |
	constrainer _ (owner == nil or: [owner viewBox == nil])
					ifTrue: [self bounds]
					ifFalse: [owner viewBox].
	self orientation == #vertical
			ifTrue:
				[self top: ((self top min: (constrainer bottom- self height)) max: 0)]
			ifFalse:
				[self left: ((self left min: (constrainer right - self width)) max: 0)]