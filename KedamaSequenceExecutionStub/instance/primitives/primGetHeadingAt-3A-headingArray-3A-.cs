primGetHeadingAt: i headingArray: headingArray

	| heading |
	<primitive: 'getScalarHeading' module:'KedamaPlugin'>
	"^ KedamaPlugin doPrimitive: #getScalarHeading."

	heading := headingArray at: i.
	^ heading := KedamaMorph radiansToDegrees: heading.
