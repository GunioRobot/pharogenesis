anyShapeFill
	"Fill the interior of the outermost outlined region in the receiver, a 1-bit deep form.  Typically the resulting form is used with fillShape:fillColor: to paint a solid color.  See also convexShapeFill:"

	| shape |
	"Draw a seed line around the edge and fill inward from the outside."
	shape _ self findShapeAroundSeedBlock: [:f | f borderWidth: 1].
	"Reverse so that this becomes solid in the middle"
	shape _ shape reverse.
	"Finally erase any bits from the original so the fill is only elsewhere"
	shape copy: shape boundingBox from: self to: 0@0 rule: Form erase.
	^ shape