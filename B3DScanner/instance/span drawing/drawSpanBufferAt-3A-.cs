drawSpanBufferAt: yValue
	| leftX rightX |
	leftX _ aet first xValue bitShift: -12.
	rightX _ aet last xValue bitShift: -12.
	bitBlt copyBitsFrom: leftX to: rightX at: yValue.