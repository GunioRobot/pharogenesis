changeScaleTo: aNumber

	| transform innerPasteup min1 min2 newScale oldPoint |

	transform _ self myTransformMorph.
	"oldScale _ transform scale."
	innerPasteup _ transform firstSubmorph.

	min1 _ transform width / innerPasteup width asFloat.
	min2 _ transform height / innerPasteup height asFloat.
	newScale _ (aNumber max: min1) max: min2.

	oldPoint _ self cameraPoint.
	transform scale: newScale.
	self cameraPoint: oldPoint.

	"scaleR _ newScale / oldScale.
	half _ transform extent // 2.
	half _ 0@0.
	self changeOffsetBy: scaleR * (transform offset + half) - half - transform offset."

"==Alan's preferred factors
pan = 0.0425531914893617
zoom = 0.099290780141844
==="
