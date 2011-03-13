indicateModalChild
	"Flash the button border."
	
	|fs c w d|
	fs := self fillStyle.
	c := self color alphaMixed: 0.5 with: Color black.
	w := self world.
	d := 0.
	2 timesRepeat: [
		(Delay forDuration: d milliSeconds) wait.
		d := 200.
		self setProperty: #fillStyle toValue: c.
		color := c.
		self invalidRect: self bounds.
		w ifNotNil: [w displayWorldSafely].
		(Delay forDuration: d milliSeconds) wait.
		self fillStyle: fs.
		w ifNotNil: [w displayWorldSafely].
		self invalidRect: self bounds]
