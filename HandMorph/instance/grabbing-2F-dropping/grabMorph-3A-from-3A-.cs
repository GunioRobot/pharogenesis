grabMorph: aMorph from: formerOwner
	"Grab the given morph (i.e., add it to this hand and remove it from its current owner) without changing its position. This is used to pick up a morph under the hand's current position, versus attachMorph: which is used to pick up a morph that may not be near this hand."
	| grabbed offset targetPoint grabTransform fullTransform |
	self releaseMouseFocus. "Break focus"
	grabbed _ aMorph.
	"Compute the transform to apply to the grabbed morph"
	grabTransform _ formerOwner 
			ifNil:[IdentityTransform new] 
			ifNotNil:[formerOwner grabTransform].
	"Compute the full transform for the grabbed morph"
	fullTransform _ formerOwner 
			ifNil:[IdentityTransform new] 
			ifNotNil:[formerOwner transformFrom: owner].
	"targetPoint is point in aMorphs reference frame"
	targetPoint _ fullTransform globalPointToLocal: self position.
	"but current position will be determined by grabTransform, so compute offset"
	offset _ targetPoint - (grabTransform globalPointToLocal: self position).
	"apply the transform that should be used after grabbing"
	grabbed _ grabbed transformedBy: grabTransform.
	grabbed == aMorph 
		ifFalse:[grabbed setProperty: #addedFlexAtGrab toValue: true].
	"offset target to compensate for differences in transforms"
	grabbed position: grabbed position - offset asIntegerPoint.
	"And compute distance from hand's position"
	targetOffset _ grabbed position - self position.
	self addMorphBack: grabbed.