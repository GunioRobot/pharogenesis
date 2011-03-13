degreesToRadians: degrees

	| deg q headingRadians |
	deg _ 90.0 - degrees.
	q _ (deg / 360.0) asInteger.
	deg < 0.0 ifTrue: [q _ q - 1].
	headingRadians _ (deg - (q * 360.0)) * 0.0174532925199433.
	^ headingRadians.
