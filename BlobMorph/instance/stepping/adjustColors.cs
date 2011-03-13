adjustColors
	"Bob Arning <arning@charm.net>"
	"Color mixing - Sean McGrath <sean@email.ces.ucsf.edu>"
	| nearbyColors center r degrees |
	center _ bounds center.
	nearbyColors _ vertices collect:
		[:each |
		degrees _ (each - center) degrees.
		r _ (each - center) r.
		Display colorAt: (Point r: r + 6 degrees: degrees) + center].
		self color: ((self color alphaMixed: 0.95 with: (Color
			r: (nearbyColors collect: [:each | each red]) average
			g: (nearbyColors collect: [:each | each green]) average
			b: (nearbyColors collect: [:each | each blue]) average))
				alpha: self color alpha).
        sneaky ifFalse: [self color: color negated]