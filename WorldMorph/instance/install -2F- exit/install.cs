install

	self viewBox: Display boundingBox.
	hands do: [:h | h initForEvents].
	SystemWindow noteTopWindowIn: self.
	self displayWorld.
