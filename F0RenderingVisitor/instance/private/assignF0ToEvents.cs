assignF0ToEvents
	| time |
	time _ 0.
	clause events do: [ :each |
		each pitchPoints: (self pitchesBetween: time and: time + each duration).
		time _ time + each duration]