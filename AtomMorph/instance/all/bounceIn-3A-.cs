bounceIn: aRect
	| p vx vy px py |
	p _ self position.
	vx _ velocity x.  vy _ velocity y.
	px _ p x + vx.  py _ p y + vy.
	px > aRect right ifTrue: [
		px _ aRect right - (px - aRect right).
		vx _ velocity x negated.
	].
	py > aRect bottom ifTrue: [
		py _  aRect bottom - (py - aRect bottom).
		vy _ velocity y negated.
	].
	px < aRect left ifTrue: [
		px _ aRect left - (px - aRect left).
		vx _ velocity x negated.
	].
	py < aRect top ifTrue: [
		py _  aRect top - (py - aRect top).
		vy _ velocity y negated.
	].
	self position: px @ py.
	self velocity: vx @ vy.
