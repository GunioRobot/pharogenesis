assignF0ToEvents
	| time |
	time := 0.
	clause events do: [ :each |
		each pitchPoints: (self pitchesBetween: time and: time + each duration).
		time := time + each duration]