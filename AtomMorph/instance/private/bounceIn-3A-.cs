bounceIn: aRect
	"Move this atom one step along its velocity vector and make it bounce if it goes outside the given rectangle. Return true if it is bounced."

	| p vx vy px py bounced |
	p _ self position.
	vx _ velocity x.		vy _ velocity y.
	px _ p x + vx.		py _ p y + vy.
	bounced _ false.
	px > aRect right ifTrue: [
		px _ aRect right - (px - aRect right).
		vx _ velocity x negated.
		bounced _ true].
	py > aRect bottom ifTrue: [
		py _  aRect bottom - (py - aRect bottom).
		vy _ velocity y negated.
		bounced _ true].
	px < aRect left ifTrue: [
		px _ aRect left - (px - aRect left).
		vx _ velocity x negated.
		bounced _ true].
	py < aRect top ifTrue: [
		py _  aRect top - (py - aRect top).
		vy _ velocity y negated.
		bounced _ true].
	self position: px @ py.
	bounced ifTrue: [self velocity: vx @ vy].
	^ bounced
