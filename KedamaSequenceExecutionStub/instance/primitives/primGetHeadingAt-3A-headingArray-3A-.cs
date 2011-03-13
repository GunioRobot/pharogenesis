primGetHeadingAt: i headingArray: headingArray

	| heading |
	<primitive: 'getScalarHeading' module:'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #getScalarHeading."

	heading _ headingArray at: i.
	^ heading _ KedamaMorph radiansToDegrees: heading.
