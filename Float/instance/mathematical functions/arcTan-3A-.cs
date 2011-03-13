arcTan: denominator
	"Answer the angle in radians.
	 Optional. See Object documentation whatIsAPrimitive."

	| result |

	(self = 0.0) ifTrue: [ (denominator > 0.0) ifTrue: [ result := 0 ]
										    ifFalse: [ result := Pi ]
						]
			    ifFalse: [(denominator = 0.0)
					ifTrue: [ (self > 0.0) ifTrue: [ result := Halfpi ]
												ifFalse: [ result := Halfpi negated ]
							]
					ifFalse: [ (denominator > 0) ifTrue: [ result := (self / denominator) arcTan ]
								 ifFalse: [ (self > 0) ifTrue: [result := ((self / denominator) arcTan) + Pi ]
															ifFalse: [result := ((self / denominator) arcTan) - Pi]
											]
							].
						].
	
	^ result.