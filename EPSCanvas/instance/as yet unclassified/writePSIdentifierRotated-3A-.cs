writePSIdentifierRotated: rotateFlag

	target print:'%!PS-Adobe-2.0 EPSF-1.2'; cr.
	rotateFlag
		ifTrue: [target print: '%%BoundingBox: '; write: psBounds rounded; cr;
					print: '90 rotate'; cr;
					print: '0 -'; write: psBounds height rounded; print: ' translate'; cr]
		ifFalse: [target print: '%%BoundingBox: '; write: psBounds rounded; cr].
	target print:'%%Title: '; write:self topLevelMorph externalName; cr.

