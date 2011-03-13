primSetHeading: headingArray from: val

	| heading |
	<primitive: 'setHeadingArrayFrom' module:'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #setHeadingArrayFrom."

	val isCollection ifFalse: [
		heading _ val asFloat.
		heading _ KedamaMorph degreesToRadians: heading.
	].

	1 to: headingArray size do: [:i |
		val isCollection ifTrue: [
			heading _ val at: i.
			heading _ KedamaMorph degreesToRadians: heading.
		].
		headingArray at: i put: heading.
	].
