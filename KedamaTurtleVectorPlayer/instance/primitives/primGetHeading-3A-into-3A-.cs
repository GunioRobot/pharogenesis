primGetHeading: headingArray into: resultArray

	| heading |
	<primitive: 'getHeadingArrayInto' module:'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #getHeadingArrayInto."

	1 to: headingArray size do: [:i |
		heading _ headingArray at: i.
		heading _ heading / 0.0174532925199433.
		heading _ 90.0 - heading.
		heading > 0.0 ifFalse: [heading _ heading + 360.0].
		resultArray at: i put: heading.
	].
