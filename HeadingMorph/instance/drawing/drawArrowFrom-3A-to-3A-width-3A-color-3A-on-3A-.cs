drawArrowFrom: p1 to: p2 width: w color: aColor on: aCanvas

	| d p |
	d _ (p1 - p2) theta radiansToDegrees.
	aCanvas line: p1 to: p2 width: w color: aColor.
	p _ p2 + (Point r: 5 degrees: d - 50).
	aCanvas line: p to: p2 width: w color: aColor.
	p _ p2 + (Point r: 5 degrees: d + 50).
	aCanvas line: p to: p2 width: w color: aColor.
