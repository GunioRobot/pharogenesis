writePSIdentifierRotated: rotateFlag
	| morphExtent pageExtent scaledBox |

	target	print:'%!PS-Adobe-2.0'; cr; 
			print:'%%Pages: (atend)'; cr.

	"Define initialScale so that the morph will fit the page rotated or not"
	savedMorphExtent _ morphExtent _ rotateFlag ifTrue: [psBounds extent transposed]
							ifFalse: [psBounds extent].

	pageExtent _ self defaultImageableArea extent asFloatPoint.
	initialScale _ pageExtent x/morphExtent x min: pageExtent y/morphExtent y.
	target print:'% initialScale: '; write:initialScale; cr.
	scaledBox _ self pageBBox rounded.
	target print: '%%BoundingBox: '; write: scaledBox rounded; cr.
	rotateFlag ifTrue: [
		target
			print: '90 rotate'; cr;
			write: self defaultMargin * initialScale;
			space;
			write: (self defaultMargin + scaledBox height * initialScale) negated;
			print: ' translate'; cr
	] ifFalse: [
		target
			write: self defaultMargin * initialScale;
			space;
			write: (self defaultMargin * initialScale);
			print: ' translate'; cr
	].
	target print: '%%EndComments'; cr.

