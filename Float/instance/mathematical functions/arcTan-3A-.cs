arcTan: denominator
	"Answer the angle in radians.
	 Optional. See Object documentation whatIsAPrimitive."

	| result |

	(self = 0.0) ifTrue: [ (denominator > 0.0) ifTrue: [ result _ 0 ]
										    ifFalse: [ result _ Pi ]
						]
			    ifFalse: [(denominator = 0.0)
					ifTrue: [ (self > 0.0) ifTrue: [ result _ Halfpi ]
												ifFalse: [ result _ Halfpi negated ]
							]
					ifFalse: [ (denominator > 0) ifTrue: [ result _ (self / denominator) arcTan ]
								 ifFalse: [ result _ ((self / denominator) arcTan) + Pi ]
							].
						].
	
	^ result.